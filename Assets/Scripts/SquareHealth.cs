using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareHealth : MonoBehaviour
{
    public int startingHealth;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        GameManager.Instance.m_EnemyKilled.AddListener(HealOnKill);
    }

    internal void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
    }

    internal void HealOnKill()
    {
        AddHealth(1);
        Debug.Log("Vampired");
    }

    internal float GetHealth()
    {
        return currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //whatever my death code is
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}

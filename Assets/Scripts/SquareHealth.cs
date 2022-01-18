using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareHealth : MonoBehaviour
{
    public int startingHealth;
    public Slider hpBar;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        hpBar.value = currentHealth;
        hpBar.maxValue = startingHealth;
    }

    internal void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

        hpBar.value = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareHealth : MonoBehaviour
{
    public int startingHealth;
    public SquareMovement sqrMove;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        sqrMove = this.gameObject.GetComponent<SquareMovement>();
    }

    internal void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (sqrMove.IsMoving())
        {
            TakeDamage(1);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}

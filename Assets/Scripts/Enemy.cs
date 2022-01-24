using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float health;
    public float strength;
    [Space]
    public float selfKnockbackForce;
    public float stunDuration;
    [Space]
    public float speed;
    public float maxSpeed;

    private float stunTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<SquareHealth>().gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (stunTimer >= 0)
        {
            stunTimer -= Time.deltaTime;
            return;
        }

        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.m_EnemyKilled.Invoke();
    }

    internal void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SquareHealth playerHealth;
        if (collision.gameObject.TryGetComponent(out playerHealth))
        {
            playerHealth.TakeDamage(strength);
            rb.velocity = Vector2.zero;
            rb.AddForce((transform.position - player.transform.position) * selfKnockbackForce * Time.deltaTime);
            stunTimer = stunDuration;
        }
    }
}


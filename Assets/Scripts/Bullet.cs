using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public float lifeDuration;
    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
        else if (lifeTimer <= lifeDuration/2)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy;
        if (collision.gameObject.TryGetComponent(out enemy) && lifeTimer > 0)
        {
            lifeTimer = 0;
            enemy.TakeDamage(bulletDamage);
        }
    }
}

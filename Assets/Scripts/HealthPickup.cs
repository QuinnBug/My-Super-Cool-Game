using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthPickup : MonoBehaviour
{
    int healAmount = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<SquareHealth>().AddHealth(healAmount);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealingToPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damageToDeal;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageToDeal);
        }
    }

}


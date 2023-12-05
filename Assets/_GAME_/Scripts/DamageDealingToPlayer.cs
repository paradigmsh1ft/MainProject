using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageDealingToPlayer : MonoBehaviour
{
    private PlayerHealth playerHealth;

    public int damageToDeal;
    private float lastDamageTime;
    private float damageInterval = 1f;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        lastDamageTime = -damageInterval; 
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && Time.time - lastDamageTime > damageInterval)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageToDeal);
            lastDamageTime = Time.time;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            lastDamageTime = -damageInterval; 
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealing : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damageToDeal;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageToDeal);
        }
    }

}


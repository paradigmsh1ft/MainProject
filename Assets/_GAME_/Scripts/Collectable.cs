using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private ICollectableHealthRegen healthRegen;
    private PlayerInventory playerInventory;

    private void Start()
    {  
        healthRegen = GetComponent<ICollectableHealthRegen>();     
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();

        if(collision.CompareTag("Player"))
        {
            healthRegen.RegenerateHealth(playerHealth);
            playerInventory.AddItem(this.gameObject);
            Destroy(this.gameObject);
        }
    }

}

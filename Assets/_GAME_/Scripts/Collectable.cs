using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private PlayerHealth playerHealth;
    private ICollectableHealthRegen healthRegen;

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

            if (gameObject.CompareTag("NotInventoryItem"))
            {
                healthRegen.RegenerateHealth(playerHealth);
            }
            else if (gameObject.CompareTag("InventoryItem"))
            {
                playerInventory.AddItem(this.gameObject);
            }
           
            Destroy(this.gameObject);
        }
    }
}

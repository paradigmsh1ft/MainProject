using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInventory playerInventory = collision.GetComponent<PlayerInventory>();

        if(collision.CompareTag("Player"))
        {
            playerInventory.AddItem(this.gameObject);
            Destroy(this.gameObject);
        }
    }

}

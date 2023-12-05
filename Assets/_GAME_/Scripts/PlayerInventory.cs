using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public const int maxInventorySize = 10;
    public const int maxQuantity = 16;

    [System.Serializable]
    public class Slot
    {
        public GameObject item;
        public int quantity;
    }

    public List<Slot> slots = new List<Slot>();
    public void AddItem(GameObject newItem)
    {
        if(slots.Count < maxInventorySize)
        {
            Slot slot = slots.Find(x => x.item == newItem);

            if (slot != null)
            {
                if (slot.quantity < maxQuantity)
                {
                    slot.quantity++;
                }
            }
            else
            {
                Slot newSlot = new Slot();
                newSlot.item = newItem;
                newSlot.quantity = 1;
                slots.Add(newSlot);
            }
            
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }  
}

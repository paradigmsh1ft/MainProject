using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour, ICollectableHealthRegen
{
    public int healthAmount = 15;
    public void RegenerateHealth(PlayerHealth playerHealth)
    {
        playerHealth.RegenHealth(healthAmount);
    }
    //Do a new special bonus that strawberry gives like a damage boost
}

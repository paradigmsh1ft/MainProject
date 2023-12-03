using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, ICollectableHealthRegen
{
    public int healthAmount = 20;
    public void RegenerateHealth(PlayerHealth playerHealth)
    {
        playerHealth.RegenHealth(healthAmount);
    }
}

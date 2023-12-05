using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour, ICollectableHealthRegen
{
    public int healthAmount = 10;

    public void RegenerateHealth(PlayerHealth playerHealth)
    {
        playerHealth.RegenHealth(healthAmount);
    }
    //Do a new special bonus that cherry gives like a stamina boost
}

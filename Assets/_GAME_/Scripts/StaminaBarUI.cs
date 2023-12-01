using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    public PlayerController playerStamina;
    public Slider staminaBar;
    
    void Start()
    {
        playerStamina = FindObjectOfType<PlayerController>();
    }

    void Update()
    {    
        staminaBar.value = playerStamina.playerStamina;
    }
}

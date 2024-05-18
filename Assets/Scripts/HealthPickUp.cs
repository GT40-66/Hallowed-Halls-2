using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{   
    public PlayerHealth playerHealth;
    public int healAmount;

     private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if object with tag "Player" is touching and if the current health is less than max
        if (other.CompareTag("Player"))
        {
            if(playerHealth != null && playerHealth.playerCurrentHealth < playerHealth.playerMaxHealth)
            {
                playerHealth.playerCurrentHealth += healAmount;
                Destroy(gameObject);
            }
        }
    }
}

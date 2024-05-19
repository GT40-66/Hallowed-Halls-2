using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int playerMaxHealth = 100;
    [SerializeField] public int playerCurrentHealth;
    public GameObject enemy;
    public EnemyController enemyController;
    public HealthBar healthBar;


    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(playerCurrentHealth);
    }

    public void TakeDamage ()
    {
        // handle player damage 
        playerCurrentHealth -= enemyController.goombaDamage;
        healthBar.SetHealth(playerCurrentHealth);

        if (playerCurrentHealth <= 0)
        {
            //Handle Player Death
            Debug.Log("Player is dead");
        }
    }
}

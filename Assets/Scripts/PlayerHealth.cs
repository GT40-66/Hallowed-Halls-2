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


    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void TakeDamage ()
    {
        // handle player damage 
        playerCurrentHealth -= enemyController.goombaDamage;

        if (playerCurrentHealth <= 0)
        {
            //Handle Player Death
            Debug.Log("Player is dead");
        }
    }
}

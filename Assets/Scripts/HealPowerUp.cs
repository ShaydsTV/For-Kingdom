using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{

    public int heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player.instance.currentHealth < 100)
            {
                // Heal()
                PlayerStatsController.instance.HealPlayer(heal);
                Destroy(gameObject);
            }            
        }
    }
}

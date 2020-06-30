using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventory.instance.AddCoin(1);
            CurrentSceneManager.instance.coinsPickedUp++;
            Destroy(transform.gameObject);
        }
    }
}

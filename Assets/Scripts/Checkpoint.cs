﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            playerSpawn.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // Destroy(gameObject);
        }
    }
}
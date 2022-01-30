using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    private DateTime respawnTime = DateTime.Now;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && (DateTime.Now - respawnTime).TotalSeconds < 2769)
        {
            
            Destroy(gameObject);
            LevelManager.instance.Respawn();
            respawnTime = DateTime.Now;
        }
    }
}

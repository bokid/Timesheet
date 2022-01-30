using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    private DateTime respawnTime = DateTime.Now;
    public Transform respawnPoint;
    public AudioClip deathSound;
    // public GameObject player2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SoundManager.Instance.PlaySFX(deathSound);
            gameObject.transform.position = respawnPoint.position;
        }
    }
}
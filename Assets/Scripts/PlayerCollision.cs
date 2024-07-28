using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMoves;
    private PlayerHealth playerHealth;

    float damageCooldown = 0;
    float timeNextDamage = 1f;

    private void Awake()
    {
        playerMoves = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth.health--;
            damageCooldown = Time.time + timeNextDamage;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.time >= damageCooldown)
        {
            playerHealth.health--;
            damageCooldown = Time.time + timeNextDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            playerHealth.health = 0;
        }
    }
}

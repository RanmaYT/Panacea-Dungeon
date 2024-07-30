using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] AudioSource hitSound;

    private PlayerHealth playerHealth;

    float damageCooldown = 0;
    float timeNextDamage = 2f;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ShadowSlime") || collision.gameObject.CompareTag("Slime"))
        {
            playerHealth.health--;
            hitSound.Play();
            healthBar.SetHealth(playerHealth.health);

            damageCooldown = Time.time + timeNextDamage;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("ShadowSlime") || collision.gameObject.CompareTag("Slime")) && Time.time >= damageCooldown)
        {
            playerHealth.health--;
            hitSound.Play();
            healthBar.SetHealth(playerHealth.health);
            damageCooldown = Time.time + timeNextDamage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            playerHealth.health = 0;
            healthBar.SetHealth(playerHealth.health);
        }
    }
}

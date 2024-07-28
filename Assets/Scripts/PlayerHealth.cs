using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    private void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}

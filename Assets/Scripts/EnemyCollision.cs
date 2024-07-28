using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public bool afterPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            afterPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            afterPlayer = false;
        }
    }
}

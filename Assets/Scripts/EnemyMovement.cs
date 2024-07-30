using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyCollision enemyCol;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private PlayerHealth playerHealth;

    private Transform target;

    private Vector2 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = target.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && enemyHealth.currentHealth > 0 && playerHealth.health != 0)
        {
            MoveEnemy(); 
        }

        if (playerHealth.health == 0 && enemyHealth.currentHealth > 0)
        {
            enemyCol.afterPlayer = false;
            transform.position = Vector2.MoveTowards(transform.position, initialPos, 1 * Time.deltaTime);
        }
    }

    private void MoveEnemy()
    {
        if (enemyCol.afterPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPos, 1 * Time.deltaTime);
        }
    }
}

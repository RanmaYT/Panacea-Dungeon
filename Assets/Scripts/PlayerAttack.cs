using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement playerMoves;

    private float hInput;
    private float nextAttackTime = 0;
    private float attackRate = 2f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRadius = 1f;
    public int damageAmount = 5;

    public bool isAttacking;

    private void Start()
    {
        playerMoves = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >  nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.X) && playerMoves.isGrounded())
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        else
        {
            isAttacking = false;
        }
    }

    void Attack()
    {
        isAttacking = true;

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);

        foreach(Collider2D enemy in enemiesHit)
        {
            Debug.Log("o Ataque ocorreu");
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}

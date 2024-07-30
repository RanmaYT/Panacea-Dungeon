using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] EtherBar etherBar;
    [SerializeField] ShadowEtherBar shadowEtherBar;

    [SerializeField] AudioSource slashAudio;

    private PlayerMovement playerMoves;
    private PlayerPoints playerPoints;

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
        playerPoints = GetComponent<PlayerPoints>();
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
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);

            slashAudio.Play();

            if (enemy.CompareTag("Slime"))
            {
                playerPoints.etherCount++;
                etherBar.SetEther(playerPoints.etherCount);
            }
            else if (enemy.CompareTag("ShadowSlime"))
            {
                playerPoints.shadowEtherCount++;
                shadowEtherBar.SetShadowEther(playerPoints.shadowEtherCount);
            }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement playerMoves;
    private PlayerHealth playerHealth;
    private PlayerAttack playerAttack;
    private PlayerCollision playerCol;

    private Animator playerAnim;
    private Rigidbody2D playerRb;

    private float horizontalInput;
    private bool isFalling;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMoves = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerCol = GetComponent<PlayerCollision>();

        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FallingChecking();

        AnimatorSetting();
        
        Flip();
    }

    private void Flip()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (playerMoves.isWalking)
        {
            if(horizontalInput == 1)
            {
                if(!facingRight)
                {
                    transform.Rotate(0, 180, 0);
                    facingRight = true;
                }

            }
            
            if(horizontalInput == -1)
            {
                if (facingRight)
                {
                    transform.Rotate(0, 180, 0);
                    facingRight = false;
                }

            }
        }
    }

    private void AnimatorSetting()
    {
        playerAnim.SetBool("isJumping", playerMoves.isJumping);
        playerAnim.SetBool("isWalking", playerMoves.isWalking);

        playerAnim.SetBool("isFalling", isFalling);
        playerAnim.SetBool("isAttacking", playerAttack.isAttacking);

        if(playerHealth.health <= 0)
        {
            playerAnim.SetBool("isDead", true);
        }
    }

    private void FallingChecking()
    {
        if(playerRb.velocity.y < -1)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }
    }
}

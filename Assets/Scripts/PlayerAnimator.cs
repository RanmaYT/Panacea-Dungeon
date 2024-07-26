using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnim;
    private SpriteRenderer playerSR;
    private PlayerMovement playerMoves;
    private PlayerHealth playerHealth;

    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMoves = GetComponent<PlayerMovement>();
        playerAnim = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("isGrounded", playerMoves.isGrounded);
        playerAnim.SetBool("isWalking", playerMoves.isWalking);
        playerAnim.SetBool("isAttacking", playerMoves.isAttacking);
        playerAnim.SetInteger("health", playerHealth.health);
        
        Flip();
    }

    private void Flip()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (playerMoves.isWalking)
        {
            if(horizontalInput == 1)
            {
                playerSR.flipX = false;
            }
            
            if(horizontalInput == -1)
            {
                playerSR.flipX = true;
            }
        }
    }
}

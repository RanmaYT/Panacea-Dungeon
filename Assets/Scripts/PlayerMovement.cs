using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1f;

    [SerializeField] GameManager manager;
    [SerializeField] AudioSource walkSound;
    [SerializeField] AudioSource jumpSound;

    private bool isPlaying;
    private float horizontalInput;
    private Rigidbody2D rb;

    public LayerMask groundLayer;
    public Vector2 boxSize;
    
    public bool isJumping;
    public bool isWalking;

    public float castDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    private void Update()
    {
        JumpInputCheck();
        CheckWalking();

        if(isGrounded() && isWalking && !manager.gameOver)
        {
            if(!isPlaying)
            {
                isPlaying = true;
                walkSound.Play();
            }
        }
        else
        {
            isPlaying = false;
            walkSound.Stop();
        }
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void PlayerJump()
    {
        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;

        }
    }

    private void CheckWalking()
    {
        if(horizontalInput != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    private void JumpInputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            isJumping = true;
            jumpSound.Play();
        }

    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float attackCooldown = 0;

    private float horizontalInput;
    private Rigidbody2D rb;

    public bool isGrounded = true;
    public bool isJumping;
    public bool isWalking;
    public bool isAttacking;


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
        AttackCheck();
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            isGrounded = false;
        }

    }

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.X) && attackCooldown <= 0 && isGrounded)
        {
            isAttacking = true;
            attackCooldown = 0.4f;

            StartCoroutine("AttackCooldown");
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);

        attackCooldown = 0;
        isAttacking = false;
    }
}

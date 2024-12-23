using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 15f;

    private Animator animator;

    private Rigidbody2D rb;

    private int jumpCount;
    private const int MAX_JUMPS = 2;
    private bool isJumping;

    private bool isGrounded;
    private float groundCheckRadius = 0.8f;
    public LayerMask Ground; 
    public Transform groundCheck;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Horizontal Movement 
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        // Walking and Idle animation
        if (moveInput > 0.05f || moveInput < - 0.05f)
        {
            animator.SetInteger("playerState", 1); // Turn on run animation
        }
        else
        {
            if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
        }

        // Flip Sprite Based on Direction
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Checks if grounded
        isGrounded = Physics2D.OverlapCircle( groundCheck.position, groundCheckRadius, Ground);

        // Resets Jump count when Grounded
        if(isGrounded && !isJumping)
        {
            jumpCount = 0; // Resets jumps when landing
        }
        
        // Jump Logic and Animation
        if (Input.GetButtonDown("Jump") && jumpCount < MAX_JUMPS)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetInteger("playerState", 2);
            jumpCount++;
            isJumping = true; // Player is in a jumping state
        }
    }

    void FixedUpdate()
    {
        // Allow jumping state to reset when falling
        if (isGrounded)
        {
            isJumping = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visual aid to check the ground collision.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

    }

}
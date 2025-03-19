using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    [SerializeField] GameObject rangedAttack;
    [SerializeField] GameObject swordAttack;

    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public static bool playerSpriteForward { get; private set; }

    private Animator animator;
    private Rigidbody2D rb;

    private int jumpCount;
    private const int MAX_JUMPS = 2;
    private bool isJumping;

    private bool isGrounded;
    private float groundCheckRadius = 0.8f;

    public LayerMask Ground; 
    public Transform groundCheck;

    void Start()
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
        {
            transform.localScale = new Vector3(1, 1, 1);
            playerSpriteForward = true;
        }
        else if(moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            playerSpriteForward = false;
        }
            
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
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // Spawn the ranged attack depending on the direction the player is facing
            if (playerSpriteForward)
            {
                Instantiate(rangedAttack, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), gameObject.transform.rotation);
            }
            else if (playerSpriteForward == false) 
            {
                Instantiate(rangedAttack, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), gameObject.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // I need to add a cooldown so player cannot spam it. 
            swordAttack.SetActive(true);

        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetInteger("playerState", 2);
        jumpCount++;
        isJumping = true; // Player is in a jumping state
    }

    void FixedUpdate()
    {
        // Allow jumping state to reset when falling, without this the player could sometimes triple jump. 
        if (isGrounded)
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with an object with the tag "enemy", this will be executed.

        if (other.gameObject.tag == "Coin")
        {
            GameManager1.Instance.AddCoin();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Enemy")
        {
            GameManager1.Instance.SetPlayerDead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit player");
            GameManager1.Instance.SetPlayerDead();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visual aid to check the ground collision.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

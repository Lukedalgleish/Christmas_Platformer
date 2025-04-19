using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellAI : MonoBehaviour
{
    public PlayerController1 player;
    public LayerMask wall;
    private Rigidbody2D rb;
    private Collider2D playerRB;
    private float shellSpeed = 4;
    private bool moveShell = false;
    public Collider2D shellCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRB = player.GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (moveShell)
        {
            rb.velocity = new Vector2(shellSpeed, rb.velocity.y);
        }
    }

    public void PlayerHitsShell()
    {
        if (!moveShell)
        {
            shellCollider.enabled = true;
            moveShell = true;
            if (player.transform.position.x <= transform.position.x)
            {
                shellSpeed = 4;

            }
            else if (player.transform.position.x > transform.position.x)
            {
                shellSpeed = -4;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            moveShell = false;
            shellCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            shellSpeed = shellSpeed * -1;
        }
    }
}

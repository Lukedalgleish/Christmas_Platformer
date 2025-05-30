using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private float moveSpeed = 10;
    private float timeBeforeDestroyed = 5;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // We check which direction the player is facing and shoot the fireball depending on that 
        if (PlayerController1.playerSpriteForward == false)
        {
            moveSpeed = -10f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the fireball

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // This is a timer that destroys the fireball after 5 seconds
        timeBeforeDestroyed -= Time.deltaTime;
        if(timeBeforeDestroyed <= 0)
        {
            Destroy(gameObject);
        }
    }
}

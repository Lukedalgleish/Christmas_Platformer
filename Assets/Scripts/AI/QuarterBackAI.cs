using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterBackAI : MonoBehaviour
{
    public Transform player;      // Reference to the player's Transform
    public float chaseDistance = 6f; // Distance at which enemy starts chasing
    public float moveSpeed = 2f;  // Enemy movement speed

    private float breakDurationTime = 3f;
    private float breakDurationRemaining;

    private Rigidbody2D rb;
    private Vector3 playersLastPosition;
    bool hasTarget = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // If player reference is not set, find the player by tag
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        breakDurationRemaining = breakDurationTime;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position); // We check the players distance from the Enemy

            if (distance <= chaseDistance && !hasTarget)
            {
                playersLastPosition = player.position;
                hasTarget = true;
                return;
            }
            Debug.Log(hasTarget);
        }
        Debug.Log(transform.position);
    }

    void FixedUpdate()
    {
        // Move enemy using Rigidbody2D physics
        if (hasTarget)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, new Vector2(playersLastPosition.x, rb.position.y), moveSpeed * Time.deltaTime);
            rb.MovePosition(newPos);

            if (Vector2.Distance(rb.position, new Vector2(playersLastPosition.x, rb.position.y)) < 0.1f)
            {
                // Add a timer for 3 seconds then turn hastarget to false. 
                breakDurationRemaining -= Time.deltaTime;
                if (breakDurationRemaining <= 0)
                {
                    hasTarget = false;
                    breakDurationRemaining = breakDurationTime;
                }

            }
        }

    }
}

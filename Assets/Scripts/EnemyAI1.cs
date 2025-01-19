using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{
    public class EnemyAI : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public LayerMask ground;
        public LayerMask wall;

        private Rigidbody2D EnemyRB;
        public Collider2D triggerCollider;

        void Start()
        {
            EnemyRB = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            EnemyRB.velocity = new Vector2(moveSpeed, EnemyRB.velocity.y);
        }

        void FixedUpdate()
        {
            if (!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }

        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Fireball")
            {
                Debug.Log("enemy got hit by the fireball");
            }
        }

    }
}

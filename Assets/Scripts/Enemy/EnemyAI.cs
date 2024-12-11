using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components.HP;

namespace Enemy.AI
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 2f;
        [SerializeField] float followSpeed = 3f;
        [SerializeField] float patrolPointA;
        [SerializeField] float patrolPointB;
        [SerializeField] float detectionRadius = 5f;
        [SerializeField] float attackRadius = 1f;
        [SerializeField] Transform m_attackPoint;
        [SerializeField] int scoreValue = 10; // Points awarded for killing this enemy

        private bool movingRight = true;
        private Transform player;
        private bool playerInRange = false;
        public bool isAttacking = false;

        public Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;

            // Subscribe to death event
            GetComponent<HPStats>().OnDeath += OnDeath;
        }

        void Update()
        {
            if (GetComponent<HPStats>().isAlive)
            {
                Patrol();
                DetectPlayer();

                if (playerInRange && !isAttacking)
                {
                    FollowPlayer();
                }

                UpdateSpriteFlip();
                UpdateAttackPointPosition();
            }
        }

        void Patrol()
        {
            if (!playerInRange)
            {
                isAttacking = false;
                if (movingRight)
                {
                    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                    if (transform.position.x >= patrolPointB)
                        movingRight = false;
                }
                else
                {
                    rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                    if (transform.position.x <= patrolPointA)
                        movingRight = true;
                }
            }
        }

        void DetectPlayer()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            playerInRange = distanceToPlayer <= detectionRadius;
        }

        void FollowPlayer()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > attackRadius)
            {
                isAttacking = false;
                rb.velocity = new Vector2(
                    player.position.x > transform.position.x ? followSpeed : -followSpeed,
                    rb.velocity.y
                );
                movingRight = player.position.x > transform.position.x;
            }
            else
            {
                isAttacking = true;
            }
        }

        void UpdateSpriteFlip()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = !movingRight;
        }

        void UpdateAttackPointPosition()
        {
            m_attackPoint.localPosition = GetComponent<SpriteRenderer>().flipX
                ? new Vector3(-0.87f, 0.12f, 0)
                : new Vector3(0.87f, 0.12f, 0);
        }

        void OnDeath()
        {
            // Notify the ScoreManager to add points
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(scoreValue);
            }

            Destroy(gameObject);
        }

        void OnDestroy()
        {
            GetComponent<HPStats>().OnDeath -= OnDeath;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(patrolPointA, transform.position.y, transform.position.z),
                            new Vector3(patrolPointB, transform.position.y, transform.position.z));
        }
    }
}

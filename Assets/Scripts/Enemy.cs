//using System.Collections;
//using UnityEngine;

//public class Enemy : MonoBehaviour
//{
//    public int health = 130;
//    private bool canAttack = true;

//    [SerializeField] private Stats stats;
//    [SerializeField] private ParticleSystem particle;
//    [Header("Throw Settings")]
//    [SerializeField] private GameObject throwObjectPrefab;
//    [SerializeField] private float throwForce = 10.0f;
//    [SerializeField] private float jumpForce = 5.0f;

//    private Rigidbody2D rb;
//    private SpriteRenderer sr;
//    private Transform player;
//    public Transform attackPoint;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//    }

//    private void Update()
//    {
//        stats.UpdateAttributes();
//        FlipX();
//        MoveToPlayer();

//        if (Input.GetKey(KeyCode.T))
//        {
//            TakeDamage(1);
//        }
//    }

//    private void MoveToPlayer()
//    {
//        if (player != null)
//        {
//            Vector3 playerDirection = player.position - transform.position;
//            playerDirection.y = 0;
//            playerDirection.Normalize();
//            transform.Translate(playerDirection * stats.MovementSpeed * Time.deltaTime);
//        }

//        if (canAttack)
//        {
//            canAttack = false;
//            StartCoroutine(AttackWithDelay());
//        }
//    }

//    private IEnumerator AttackWithDelay()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(4.0f); // Adjust the delay time between attacks

//            Attack();
//            canAttack = true;
//        }
//    }

//    private void Attack()
//    {
//        if (throwObjectPrefab != null)
//        {
//            GameObject thrownObject = Instantiate(throwObjectPrefab, attackPoint.position, Quaternion.identity);
//            Rigidbody2D thrownRB = thrownObject.GetComponent<Rigidbody2D>();

//            if (thrownRB != null && player != null)
//            {
//                Vector2 throwDirection = (player.position - attackPoint.position).normalized;
//                thrownRB.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
//            }
//            StartCoroutine(DestroyThrownObject(thrownObject));
//        }
//    }

//    private IEnumerator DestroyThrownObject(GameObject thrownObject)
//    {
//        yield return new WaitForSeconds(3.0f); // Adjust the delay before destruction

//        // Check if the thrownObject still exists before destroying it
//        if (thrownObject != null)
//        {
//            Destroy(thrownObject);
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        health -= damage;
//        particle.Play();

//        if (health <= 0)
//        {
//            Die();
//        }
//    }

//    private void Die()
//    {
//        Debug.Log("Enemy defeated");
//        Destroy(gameObject);
//    }

//    private void FlipX()
//    {
//        if (rb.velocity.x < 0)
//        {
//            sr.flipX = true;
//        }
//        else if (rb.velocity.x > 0)
//        {
//            sr.flipX = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.collider.CompareTag("Player"))
//        {
//            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
//            if (playerHealth != null)
//            {
//                playerHealth.TakeDamage(stats.Damage);
//                Debug.Log("Enemy attacks for " + stats.Damage + " damage!");
//            }
//        }
//        else if (collision.collider.CompareTag("Ground"))
//        {
//            Jump(collision);
//        }
//    }

//    private void Jump(Collision2D collision)
//    {
//        if (collision.collider.CompareTag("Ground"))
//        {
//            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//        }
//    }
//}








///*using System.Collections;
//using UnityEngine;

//public class Enemy : MonoBehaviour
//{
//    public int health = 130;
//    private bool canAttack = true;

//    [SerializeField] private Stats stats;
//    [SerializeField] private ParticleSystem particle;
//    [Header("Throw Settings")]
//    [SerializeField] private GameObject throwObjectPrefab;
//    [SerializeField] private float throwForce = 10.0f;
//    [SerializeField] private float jumpForce = 5.0f;
//    [SerializeField] private Transform player;

//    public float playerSearchRadius = 10.0f;
//    private GameObject thrownObject;
//    private Rigidbody2D rb;
//    private SpriteRenderer sr;
//    // private Transform player;
//    public Transform attackPoint;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//    }

//    private void Update()
//    {
//        stats.UpdateAttributes();
//        FlipX();
//        MoveToPlayer();

//        if (Input.GetKey(KeyCode.T))
//        {
//            TakeDamage(1);
//        }
//    }

//    private void MoveToPlayer()
//    {
//        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
//        if (playerObject != null && canAttack)
//        {
//            Vector3 playerDirection = playerObject.transform.position - transform.position;
//            playerDirection.y = 0;
//            playerDirection.Normalize();
//            transform.Translate(playerDirection * stats.MovementSpeed * Time.deltaTime);

//            canAttack = false;
//            StartCoroutine(AttackWithDelay());
//        }
//    }

//    private IEnumerator AttackWithDelay()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(4.0f); // Adjust the delay time between attacks

//            Attack();
//            canAttack = true;
//        }
//    }

//    private void Attack()
//    {
//        FindNearestPlayer();

//        if (player != null)
//        {
//            if (throwObjectPrefab != null)
//            {
//                GameObject thrownObject = Instantiate(throwObjectPrefab, attackPoint.position, Quaternion.identity);
//                Rigidbody2D thrownRB = thrownObject.GetComponent<Rigidbody2D>();

//                if (thrownRB != null)
//                {
//                    Vector2 throwDirection = (player.position - attackPoint.position).normalized;
//                    thrownRB.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
//                }
//                StartCoroutine(DestroyThrownObject(thrownObject));
//            }
//        }
//    }

//    void FindNearestPlayer()
//    {
//        Collider2D[] playersInRange = Physics2D.OverlapCircleAll(transform.position, playerSearchRadius, LayerMask.GetMask("Player"));
//        float nearestDistance = Mathf.Infinity;
//        Transform nearestPlayer = null;

//        foreach (Collider2D playerCollider in playersInRange)
//        {
//            float distanceToPlayer = Vector2.Distance(transform.position, playerCollider.transform.position);
//            if (distanceToPlayer < nearestDistance)
//            {
//                nearestDistance = distanceToPlayer;
//                nearestPlayer = playerCollider.transform;
//            }
//        }

//        player = nearestPlayer; // Set the player variable to the nearest player found
//    }

//    private IEnumerator DestroyThrownObject(GameObject thrownObject)
//    {
//        yield return new WaitForSeconds(3.0f); // Adjust the delay before destruction

//        if (thrownObject != null)
//        {
//            Destroy(thrownObject);
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        health -= damage;
//        particle.Play();

//        if (health <= 0)
//        {
//            Die();
//        }
//    }

//    private void Die()
//    {
//        Debug.Log("Enemy defeated");
//        Destroy(gameObject);
//    }

//    private void FlipX()
//    {
//        if (rb.velocity.x < 0)
//        {
//            sr.flipX = true;
//        }
//        else if (rb.velocity.x > 0)
//        {
//            sr.flipX = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.collider.CompareTag("Player"))
//        {
//            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
//            if (playerHealth != null)
//            {
//                playerHealth.TakeDamage(stats.Damage);
//                Debug.Log("Enemy attacks for " + stats.Damage + " damage!");
//            }
//        }
//        else if (collision.collider.CompareTag("Ground"))
//        {
//            Jump();
//        }
//    }

//    private void Jump()
//    {
//        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//    }
//}

//*/
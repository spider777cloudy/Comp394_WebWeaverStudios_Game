///*using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Combat : MonoBehaviour
//{
//    [SerializeField] private Animator animator;
//    [SerializeField] private Stats stats;
//    [SerializeField] private Equipment.Weaponry weapon;
//    [SerializeField] private GameObject target;
//    [SerializeField] private float weaponRange = 1.0f; // Set a default value


//    private Transform enemy;
//    public Transform attackPoint;
//    public LayerMask attackLayer;
//    public GameObject throwObjectPrefab; // Assign your prefab in the Inspector
//    public Transform throwPoint; // The point from where the object will be thrown
//    public float throwForce = 10f; // The force applied to the thrown object

//    public bool CanAttack { get; private set; } = true;

//    private void Awake()
//    {
//        animator = GetComponent<Animator>();
//        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
//    }

//    void Update()
//    {
//        if (CanAttack && Input.GetKey(KeyCode.Mouse0) && Time.time >= stats.AttackTime)
//        {
//            Attack();
//            stats.AttackTime = Time.time + 1f / stats.AttackCD;
//        }
        
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            ThrowObject();
//        }
//    }

//    void Attack()
//    {
//        animator.SetTrigger("Attack");

//        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, attackLayer);   // weapon.weaponRange

//        foreach (Collider2D enemy in hitEnemies)
//        {
//            Enemy enemyScript = enemy.GetComponent<Enemy>();
//            if (enemyScript != null)
//            {
//                enemyScript.TakeDamage(stats.Damage);
//            }
//        }
//    }

//    void ThrowObject()
//    {
//        if (throwObjectPrefab != null && throwPoint != null)
//        {
//            GameObject thrownObject = Instantiate(throwObjectPrefab, throwPoint.position, Quaternion.identity);
//            Rigidbody2D thrownRB = thrownObject.GetComponent<Rigidbody2D>();

//            if (thrownRB != null)
//            {
//                // Calculate the direction towards the enemy (replace 'enemyPosition' with your actual target's position)
//                Vector2 throwDirection = (enemy.position - throwPoint.position).normalized;
//                thrownRB.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
//            }
//            StartCoroutine(DestroyThrownObject(thrownObject));
//        }
//    }

//    private IEnumerator DestroyThrownObject(GameObject thrownObject)
//    {
//        yield return new WaitForSeconds(2.0f); // Adjust the delay before destruction

//        // Check if the thrownObject still exists before destroying it
//        if (thrownObject != null)
//        {
//            Destroy(thrownObject);
//        }
//    }
//    private void OnDrawGizmosSelected()
//    {
//        if (attackPoint == null)
//        {
//            return;
//        }

//        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
//    }

    
//}


//*/


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Combat : MonoBehaviour
//{
//    [SerializeField] private Animator animator;
//    [SerializeField] private Stats stats;
//    [SerializeField] private GameObject target;
//    [SerializeField] private float weaponRange = 1.0f; // Set a default value

//    public float enemySearchRadius = 10.0f; // Adjust as needed
//    private Transform enemy;
//    public Transform attackPoint;
//    public LayerMask attackLayer;
//    public GameObject throwObjectPrefab; // Assign your prefab in the Inspector
//    public Transform throwPoint; // The point from where the object will be thrown
//    public float throwForce = 10f; // The force applied to the thrown object

//    private GameObject thrownObject; // Declaring thrownObject as a class member variable

//    public bool CanAttack { get; private set; } = true;

//    private void Awake()
//    {
//        animator = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        FindNearestEnemy();

//        if (CanAttack && Input.GetKey(KeyCode.Mouse0) && Time.time >= stats.AttackTime)
//        {
//            Attack();
//            stats.AttackTime = Time.time + 1f / stats.AttackCD;
//        }

//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            ThrowObject();
//        }
//    }

//    void FindNearestEnemy()
//    {
//        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, enemySearchRadius, LayerMask.GetMask("Enemy"));
//        float nearestDistance = Mathf.Infinity;
//        Transform nearestEnemy = null;

//        foreach (Collider2D enemyCollider in enemiesInRange)
//        {
//            float distanceToEnemy = Vector2.Distance(transform.position, enemyCollider.transform.position);
//            if (distanceToEnemy < nearestDistance)
//            {
//                nearestDistance = distanceToEnemy;
//                nearestEnemy = enemyCollider.transform;
//            }
//        }

//        enemy = nearestEnemy;
//        // Ensure the object gets destroyed even if the enemy is killed
//        if (nearestEnemy == null)
//        {
//            StartCoroutine(DestroyThrownObject(thrownObject));
//        }
//    }

//    void Attack()
//    {
//        animator.SetTrigger("Attack");

//        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, attackLayer);

//        foreach (Collider2D enemyCollider in hitEnemies)
//        {
//            Enemy enemyScript = enemyCollider.GetComponent<Enemy>();
//            if (enemyScript != null)
//            {
//                enemyScript.TakeDamage(stats.Damage);
//            }
//        }
//    }

//    void ThrowObject()
//    {
//        if (throwObjectPrefab != null && throwPoint != null)
//        {
//            thrownObject = Instantiate(throwObjectPrefab, throwPoint.position, Quaternion.identity);
//            Rigidbody2D thrownRB = thrownObject.GetComponent<Rigidbody2D>();

//            if (thrownRB != null)
//            {
//                Vector2 throwDirection = (enemy.position - throwPoint.position).normalized;
//                Debug.Log("Throw direction: " + throwDirection);

//                Debug.DrawRay(throwPoint.position, throwDirection * 10f, Color.red, 2f);
//                thrownRB.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
//            }
//            StartCoroutine(DestroyThrownObject(thrownObject));
//        }
//    }

//    /*void ThrowObject()
//    {
//        if (throwObjectPrefab != null && throwPoint != null && enemy != null) // Check if enemy is not null
//        {
//            Vector2 throwDirection = (enemy.position - throwPoint.position).normalized;
//            Debug.Log("Throw direction: " + throwDirection); // Log the throw direction

//            Debug.DrawRay(throwPoint.position, throwDirection * 10f, Color.red, 2f); // Visualize the throw direction

//            Rigidbody2D thrownRB = thrownObject.GetComponent<Rigidbody2D>();

//            if (thrownRB != null)
//            {
//                thrownRB.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
//            }
//            StartCoroutine(DestroyThrownObject(thrownObject));
//        }
//        else
//        {
//            Debug.LogWarning("Enemy or throw variables are null.");
//        }
//    }*/

//    private IEnumerator DestroyThrownObject(GameObject thrownObject)
//    {
//        yield return new WaitForSeconds(2.0f); // Adjust the delay before destruction

//        if (thrownObject != null)
//        {
//            Destroy(thrownObject);
//        }
//    }

//    private void OnDrawGizmosSelected()
//    {
//        if (attackPoint == null)
//        {
//            return;
//        }

//        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
//    }


//    // Other methods or functions...
//}

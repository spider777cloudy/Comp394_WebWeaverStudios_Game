//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MovementVM : MonoBehaviour
//{
//    [SerializeField] private Stats stats;
//    [SerializeField] private Animator animator;
//    private Rigidbody2D rb;
//    private SpriteRenderer sr;
//    public AudioManager audioManager;

//    public float moveSpeed = 5f;
//    public float jumpForce = 14f;
//    public float gravityScale = 2.5f;


//    public bool isGrounded = false;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//        rb.gravityScale = gravityScale;
//    }

//    private void Update()
//    {
//        // stats.UpdateAttributes();
//        // MovementPlayer();
//        // Jump();
//        FlipX();


//        float horizontalMovement = Input.GetAxis("Horizontal");
//        Vector3 movement = new Vector3(horizontalMovement * moveSpeed, rb.velocity.y, 0f);
//        rb.velocity = movement;

//        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

//        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
//        {
//            Jump();
//        }
//    }

//    bool IsGrounded()
//    {
//        // Cast a short ray downwards to check for ground
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

//        return hit.collider != null;
//    }

//    #region METHODS
//    /* private void MovementPlayer()
//     {
//         float moveInput = Input.GetAxis("Horizontal");
//         Vector2 moveVelocity = new Vector2(moveInput * stats.MovementSpeed, rb.velocity.y);
//         rb.velocity = moveVelocity;

//         animator.SetFloat("Speed", Mathf.Abs(moveInput));
//     }
// */
//    private void Jump()
//    {
//        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
//    }

//    private void FlipX()
//    {
//        if (rb.velocity.x < 0)
//        {
//            sr.flipX = true;
//        }

//        if (rb.velocity.x > 0)
//        {
//            sr.flipX = false;
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            animator.SetBool("IsJumping", false);

//            isGrounded = true;

//            audioManager.Play("AC");
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = false;
//        }
//    }
//    #endregion
//}


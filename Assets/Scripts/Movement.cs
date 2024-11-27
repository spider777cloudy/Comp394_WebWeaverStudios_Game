//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Movement : MonoBehaviour
//{
//    [SerializeField] private Stats stats;
//    [SerializeField] private Animator animator;
//    private Rigidbody2D rb;
//    private SpriteRenderer sr;
//    public AudioManager audioManager;

//    public bool isGrounded = false;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//    }

//    private void Update()
//    {
//        stats.UpdateAttributes();
//        MovementPlayer();
//        Jump();
//        FlipX();
//    }

//    #region METHODS
//    private void MovementPlayer()
//    {
//        float moveInput = Input.GetAxis("Horizontal");
//        Vector2 moveVelocity = new Vector2(moveInput * stats.MovementSpeed, rb.velocity.y);
//        rb.velocity = moveVelocity;

//        animator.SetFloat("Speed", Mathf.Abs(moveInput));
//    }

//    private void Jump()
//    {
//        if (Input.GetButtonDown("Jump") && isGrounded)
//        {
//            animator.SetBool("IsJumping", true);

//            rb.AddForce(Vector2.up * stats.JumpPower, ForceMode2D.Impulse);
//        }
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


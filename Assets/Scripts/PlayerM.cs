using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    public float speed = 5f;
    public float jumpPower = 10f;

  //  public bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovementPlayer();
        Jump();
        FlipX();
    }

    #region METHODS
    private void MovementPlayer()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = moveVelocity;


        if (moveInput != 0)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") )
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
        if (Input.GetButtonUp("Jump"))
        {
           
            animator.SetTrigger("Idle");
        }
    }

    private void FlipX()
    {
        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
        }

        if (rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }

   
    #endregion
}
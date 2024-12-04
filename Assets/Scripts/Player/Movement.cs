using UnityEngine;

public class Movement : MonoBehaviour
{
    private GroundSensor m_groundSensor;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator m_animator;
    public bool m_grounded = false;


    public float speed = 5f;
    public float jumpPower = 10f;
    public int jumpCount = 0;
    private const int maxJumps = 2;

    //  public bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<GroundSensor>();
    }

    private void Update()
    {
        MovementPlayer();
        Jump();
        FlipX();

        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            jumpCount = 0;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeedY", rb.velocity.y);
    }

    /*void OnCollisionStay()
    {
        m_grounded = true;
    }
    void OnCollisionExit()
    {
        m_grounded = false;
    }*/

    public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Trap")
        //{
        //    GameManager.health -= 1;
        //}

        //if (other.gameObject.tag == "Potion")
        //{
        //    GameManager.health -= 1;
        //}

        if (other.gameObject.tag == "Coin")
        {
           // ScoreManager.scoreCount += 1;
        }
    }

    #region METHODS
    private void MovementPlayer()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * speed, rb.velocity.y);
        rb.velocity = moveVelocity;


        if (moveInput != 0)
        {
            m_animator.SetTrigger("Walk");
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }
        else
        {
            m_animator.SetTrigger("Idle");
            m_grounded = true;
            jumpCount = 0;
            m_animator.SetBool("Grounded", m_grounded);
        }


    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && m_grounded && jumpCount < maxJumps)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            m_animator.SetTrigger("Jump");
            jumpCount++;  // Increment jump count each time the player jumps

            // If the player has used both jumps, set grounded to false
            if (jumpCount >= maxJumps)
            {
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_groundSensor.Disable(0.2f);
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            m_animator.SetTrigger("Idle");
        }
    }

    public void OnJumpButtonPressed()
    {
        // Ensure the player can only jump if grounded

        rb.velocity = new Vector2(rb.velocity.x, jumpPower); // Apply vertical force
        m_animator.SetTrigger("Jump");
        m_grounded = false; // Set grounded to false until landing

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
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed of the player
    public float jumpForce = 10f; // Jump force for the player
    private Rigidbody2D rb;       // Reference to the Rigidbody2D component
    private bool isGrounded;      // Check if the player is on the ground
    private float moveInput;      // Horizontal movement input

    // For controlling button press simulation
    private bool moveLeft = false;
    private bool moveRight = false;
    private bool jump = false;

    public Transform groundCheck;  // Transform to check if player is on the ground
    public LayerMask groundLayer;  // Ground layer mask

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        CheckGroundStatus();

        // Check if jump is pressed
        if (jump && isGrounded)
        {
            Jump();
        }
    }

    // Handle Player Movement
    private void MovePlayer()
    {
        // Set moveInput based on button presses
        if (moveLeft)
        {
            moveInput = -1f; // Move left
        }
        else if (moveRight)
        {
            moveInput = 1f; // Move right
        }
        else
        {
            moveInput = 0f; // No movement
        }

        // Apply movement to the player
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    // Check if the player is on the ground
    private void CheckGroundStatus()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    // Jump the player
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jump = false; // Reset jump after applying force
    }

    // Methods to control the button press
    public void OnMoveLeftPressed()
    {
        moveLeft = true;
        Debug.Log("OnJumpPressed");
    }

    public void OnMoveLeftReleased()
    {
        moveLeft = false;
    }

    public void OnMoveRightPressed()
    {
        moveRight = true;
    }

    public void OnMoveRightReleased()
    {
        moveRight = false;
    }

    public void OnJumpPressed()
    {
        jump = true;
        Debug.Log("OnJumpPressed");
    }
}

/*using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 14f;
    public float gravityScale = 2.5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMovement * moveSpeed, rb.velocity.y, 0f);
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    bool IsGrounded()
    {
        // Cast a short ray downwards to check for ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        return hit.collider != null;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
*/
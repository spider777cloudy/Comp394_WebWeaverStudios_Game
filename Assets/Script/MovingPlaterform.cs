using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 0.7f; // Adjust the speed as needed
    public float moveDistance = 1.5f; // Adjust the distance as needed

    private Vector2 initialPosition;
    private int direction = 1; // 1 for right, -1 for left

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the platform horizontally
        float newPositionX = initialPosition.x + direction * moveDistance * Mathf.Sin(Time.time * moveSpeed);
        transform.position = new Vector2(newPositionX, transform.position.y);
    }
}

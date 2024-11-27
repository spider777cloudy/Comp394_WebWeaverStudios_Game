/*using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Implement any additional logic, such as checking for player death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement logic for player death (e.g., respawn or destroy)
        Debug.Log("Player has died!");
        Destroy(gameObject); // Destroy the player GameObject
    }
}
*/
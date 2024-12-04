using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 20; // Damage dealt to enemies
    [SerializeField] private int maxHealth = 100; // Player's maximum health
    [SerializeField] private Slider healthBar; // Reference to the health bar slider

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        // Initialize the health bar
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDamage enemy = collision.gameObject.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Player took {amount} damage. Current Health: {currentHealth}");

        // Update the health bar
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add logic for player death (e.g., Game Over screen, restart level)
        Destroy(gameObject);
    }
}

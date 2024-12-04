using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10; // Damage dealt to the player
    [SerializeField] private int maxHealth = 50; // Enemy's maximum health
    [SerializeField] private int scoreValue = 5; // Score gained when the enemy is killed

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDamage player = collision.gameObject.GetComponent<PlayerDamage>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Enemy took {amount} damage. Current Health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died!");
        Destroy(gameObject); 


        // Increase the score
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }
}

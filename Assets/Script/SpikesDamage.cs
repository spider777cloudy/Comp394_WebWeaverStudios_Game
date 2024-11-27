using UnityEngine;

public class SpikesDamage : MonoBehaviour
{
    public int damageAmount = 10; // Adjust the damage amount as needed

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Apply damage to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}

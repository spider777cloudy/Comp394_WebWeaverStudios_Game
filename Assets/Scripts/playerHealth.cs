using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Adjust the player's health as needed
    [SerializeField] private ParticleSystem particle;

    public void TakeDamage(int damage)
    {
        health -= damage;
        particle.Play();
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement player death logic here


        Debug.Log("Player defeated");
        Destroy(gameObject);
    }
}

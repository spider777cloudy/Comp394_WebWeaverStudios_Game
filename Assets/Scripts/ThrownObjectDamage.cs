using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownObjectDamage : MonoBehaviour
{
    [SerializeField] private Stats stats;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(stats.Damage);
                Debug.Log("Enemy attacks for " + stats.Damage + " damage!");
            }
        }
    }
}
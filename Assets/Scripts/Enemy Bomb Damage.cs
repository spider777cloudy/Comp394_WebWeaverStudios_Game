//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyBombDamage : MonoBehaviour
//{
//    [SerializeField] private Stats stats;
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.collider.CompareTag("Enemy"))
//        {
//            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
//            if (enemyScript != null)
//            {
               
               
                
//                    enemyScript.TakeDamage(stats.Damage);
               
//               Debug.Log("Player attacks for " + stats.Damage + " damage!");
//            }
//        }
//    }
//}

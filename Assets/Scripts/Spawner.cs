using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Stats stats;
    [SerializeField] private GameObject slime;
    [SerializeField] private Animator animator;

    private float spawningCooldown = 20; // Number of seconds before Spawner spawns a slime

    void Update()
    {
        SpawnEnemies();
        Damaged();
    }
    private void SpawnEnemies()
    {
        ;
    }
    private void Damaged()
    {
        if (stats.HP <= 50)
        {
            ;
        }
        else if (stats.HP <= 25)
        {
            ;
        }
        else if (stats.HP <= 10)
        {
            ;
        }
        else
        {
            ;
        }
    }
}
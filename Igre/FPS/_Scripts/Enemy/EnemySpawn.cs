using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform playerTarget;
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 3f;
    
    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer <= 0)
        {
          EnemyMovement enemyMovement = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
          enemyMovement.playerTarget = playerTarget;
            spawnTimer = spawnInterval;
        }
    }
}

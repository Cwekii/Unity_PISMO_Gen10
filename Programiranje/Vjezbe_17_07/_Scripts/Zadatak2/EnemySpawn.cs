using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform target;
    
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnTimer = 2f;
    
    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
           Enemy enemy = Instantiate(enemyPrefab,spawnPoint.position, Quaternion.identity);
           enemy.target = target;
            spawnTimer = 2f;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}

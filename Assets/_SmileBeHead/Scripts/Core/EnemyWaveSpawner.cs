using System.Collections;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    [Header("Spawn Setup")]
    [SerializeField] private EnemyController enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Wave Settings")]
    [SerializeField] private int startEnemies = 3;
    [SerializeField] private int enemiesPerWaveIncrease = 2;
    [SerializeField] private float spawnDelay = 0.5f;

    private int currentWave = 0;
    private int aliveEnemies = 0;


    private void OnEnable()
    {
        EnemyController.OnEnemyKilled += HandleEnemyKilled;
    }
    private void OnDisable()
    {
        EnemyController.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void Start()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentWave++;
        int enemiesToSpawn = startEnemies + enemiesPerWaveIncrease * (currentWave - 1);

        StartCoroutine(SpawnWave(enemiesToSpawn));
    }

    private IEnumerator SpawnWave(int count)
    {
        aliveEnemies = count;

        for(int i = 0;  i < count; i++)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemies()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

    }

    private void HandleEnemyKilled(EnemyController enemy)
    {
        aliveEnemies--;

        if (aliveEnemies <= 0)
        {
            StartNextWave();
        }
    }
}

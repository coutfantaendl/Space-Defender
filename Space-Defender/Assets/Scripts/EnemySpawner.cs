using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float speed;
    [SerializeField] private int health;

    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeBetweenSpawns;

    private float waveCountdown;
    private float spawnCountdown;
    private int waveNumber = 1;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        spawnCountdown = 0f;

        SpawnWave();
    }

    private void Update()
    {
        CalculateTimeToNextWave();
    }

    private void SpawnWave()
    {
        speed += 0.2f;
        health += 1;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }

        waveNumber++;
        waveCountdown = timeBetweenWaves;

        timeBetweenSpawns = Mathf.Max(0.5f, timeBetweenSpawns - 0.1f);
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        var enemyPrefab = Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

        var enemy = enemyPrefab.GetComponent<Enemy>();

        enemy.Initialize(speed, health);
    }

    private void CalculateTimeToNextWave()
    {
        if (waveCountdown <= 0)
        {
            if (spawnCountdown <= 0)
            {
                SpawnWave();
                spawnCountdown = timeBetweenSpawns;
            }
            else
            {
                spawnCountdown -= Time.deltaTime;
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
}

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float timeBetweenSpawns;

    private float waveCountdown;
    private float spawnCountdown;
    private int waveNumber = 1;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
        spawnCountdown = 0f;
    }

    void Update()
    {
        if(waveCountdown <= 0)
        {
            if(spawnCountdown <= 0)
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

    private void SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }

        waveNumber++;
        waveCountdown = timeBetweenWaves;

        foreach (var enemyPrefab in enemyPrefabs)
        {
            var enemy = enemyPrefab.GetComponent<Enemy>();

            enemy.speed += 0.5f;
            enemy.health += 1;
        }

        timeBetweenSpawns = Mathf.Max(0.5f, timeBetweenSpawns - 0.1f);
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}

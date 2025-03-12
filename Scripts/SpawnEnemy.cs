using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float delayTime = 3f;
    private BasicEnemySpawner enemySpawner;
    [SerializeField] protected int enemyMaxCount = 1;

    [SerializeField] private List<Transform> spawnPoints;

    private void Reset()
    {
        this.LoadSpawnPoint();
    }
    private void LoadSpawnPoint()
    {
        if (this.spawnPoints.Count > 0) return;
        foreach (Transform spawnPoint in this.transform)
        {
            this.spawnPoints.Add(spawnPoint);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }
    private void Start()
    {
        enemySpawner = BasicEnemySpawner.Instance;
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (enemySpawner.SpawnedCount < enemyMaxCount)
            {
                enemySpawner.SpawnEnemy(enemySpawner.RandomPrefabs().name, RandomSpawnPoint().position, RandomSpawnPoint().rotation);
                //enemySpawner.SpawnEnemy("Frog", RandomSpawnPoint().position, RandomSpawnPoint().rotation);
            }
            yield return new WaitForSeconds(delayTime);
        }
    }
    private Transform RandomSpawnPoint()
    {
        int rand = Random.Range(0, spawnPoints.Count);
        return spawnPoints[rand];
    }
}

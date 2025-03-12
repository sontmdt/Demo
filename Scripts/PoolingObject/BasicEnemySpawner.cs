using System;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawner : Spawner
{
    protected List<ObjectPool> enemyPool = new List<ObjectPool>();
    private Vector3 spawnPoint = Vector3.zero;
    public Vector3 SpawnPoint => spawnPoint;
    //Singleton
    private static BasicEnemySpawner instance;
    public static BasicEnemySpawner Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log($"Only one {transform.name} is allowed to exist.");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        foreach (EnemyCode enemy in Enum.GetValues(typeof(EnemyCode)))
        {
            enemyPool.Add(new ObjectPool(this.GetPrefabByName(enemy.ToString()), pool, 25, 100));
        }
    }
    public Transform SpawnEnemy(string enemyName, Vector3 spawnPos, Quaternion spawnRot)
    {
        spawnPoint = spawnPos;
        spawnedCount++;
        ObjectPool selectedPool = enemyPool.Find(x => x.Prefab.name == enemyName);
        return SpawnObject(selectedPool, spawnPos, spawnRot);
    }
    public void RemoveEnemy(string enemyName, Transform _object)
    {
        spawnedCount--;
        ObjectPool selectedPool = enemyPool.Find(x => x.Prefab.name == enemyName);
        RemoveObject(selectedPool, _object);
    }
}

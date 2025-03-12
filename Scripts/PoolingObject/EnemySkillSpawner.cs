using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillSpawner : Spawner
{
    protected List<ObjectPool> enemySkillPool = new List<ObjectPool>();

    private Vector3 spawnPoint = Vector3.zero;
    public Vector3 SpawnPoint => spawnPoint;

    [SerializeField] private List<Skill> skill;
    public List<Skill> Skill => skill;

    private string skillName;
    public string SkillName => skillName;
    //Singleton
    private static EnemySkillSpawner instance;
    public static EnemySkillSpawner Instance => instance;
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
    //
    protected override void Reset()
    {
        base.Reset();
        foreach (EnemySkillCode enemySkill in Enum.GetValues(typeof(EnemySkillCode)))
        {
            string path = "Skills/EnemySkill/" + enemySkill.ToString();
            skill.Add(Resources.Load<Skill>(path));
        }
    }
    private void Start()
    {
        foreach (EnemySkillCode enemySkill in Enum.GetValues(typeof(EnemySkillCode)))
        {
            enemySkillPool.Add(new ObjectPool(this.GetPrefabByName(enemySkill.ToString()), pool, 25, 100));
        }
    }
    private Transform SpawnEnemySkill(string enemySkillName, Vector3 spawnPos, Quaternion spawnRot)
    {
        skillName = enemySkillName;
        spawnPoint = spawnPos;
        ObjectPool selectedPool = enemySkillPool.Find(x => x.Prefab.name == enemySkillName);
        return SpawnObject(selectedPool, spawnPos, spawnRot);
    }
    public void RemoveBasicSkill(Transform _object)
    {
        ObjectPool selectedPool = enemySkillPool.Find(x => x.Prefab.name == skillName);
        if (selectedPool == null) return;
        RemoveObject(selectedPool, _object);
    }
    public override void SpawnFromEnemyToPlayer(string enemySkillName, Vector3 spawnPosition)
    {
        if (enemySkillName == "" || enemySkillName == null) return;
        base.SpawnFromEnemyToPlayer(enemySkillName, spawnPosition);
        Transform newObject = SpawnEnemySkill(enemySkillName, spawnPosition, spawnRot);
    }
}

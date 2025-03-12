using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkillSpawner : Spawner
{
    private string skillOne = "FireBall";
    protected ObjectPool basicSkillPool;
    private Vector3 spawnPoint = Vector3.zero;
    public Vector3 SpawnPoint => spawnPoint;

    [SerializeField] private Skill skill;
    public Skill Skill => skill;
    //Singleton
    private static BasicSkillSpawner instance;
    public static BasicSkillSpawner Instance => instance;
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
        string path = "Skills/BasicSkill/" + skillOne;
        skill = Resources.Load<Skill>(path);
    }
    private void Start()
    {
        basicSkillPool = new ObjectPool(this.GetPrefabByName(skillOne), pool, 25, 100);
    }
    private Transform SpawnBasicSkill(Vector3 spawnPos, Quaternion spawnRot)
    {
        spawnPoint = spawnPos;
        return SpawnObject(basicSkillPool, spawnPos, spawnRot);
    }
    public void RemoveBasicSkill(Transform _object)
    {
        RemoveObject(basicSkillPool, _object);
    }
    public override void SpawnFromPlayerToMouse()
    {
        base.SpawnFromPlayerToMouse();
        Transform newObject = SpawnBasicSkill(spawnFromPlayer, spawnRot);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillSpawner : Spawner
{
    private string skillOne = "Teleport";
    protected ObjectPool dashSkillPool;
    private Vector3 spawnPoint = Vector3.zero;
    public Vector3 SpawnPoint => spawnPoint;

    private float spawnTime = 0f;
    public float SpawnTime => spawnTime;

    [SerializeField] private Skill skill;
    public Skill Skill => skill;
    //Singleton
    private static DashSkillSpawner instance;
    public static DashSkillSpawner Instance => instance;
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
        string path = "Skills/DashSkill/" + skillOne;
        skill = Resources.Load<Skill>(path);
    }
    private void Start()
    {
        dashSkillPool = new ObjectPool(this.GetPrefabByName(skillOne), pool, 25, 100);
    }
    public Transform SpawnDashSkill(Vector3 spawnPos, Quaternion spawnRot)
    {
        spawnPoint = spawnPos;
        spawnTime = Time.time;
        return SpawnObject(dashSkillPool, spawnPos, spawnRot);
    }
    public void RemoveDashSkill(Transform _object)
    {
        RemoveObject(dashSkillPool, _object);
    }
    //public override void SpawnFormPlayerToMouse()
    //{
    //    base.SpawnFormPlayerToMouse();
    //    Transform newObject = SpawnDashSkill(spawnPos, spawnRot);
    //}
}

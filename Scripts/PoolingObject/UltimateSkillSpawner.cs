using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkillSpawner : Spawner
{
    private string skillOne = "LightningStorm";
    protected ObjectPool ultimateSkillPool;
    private Vector3 spawnPoint = Vector3.zero;
    public Vector3 SpawnPoint => spawnPoint;

    private float spawnTime = 0f;
    public float SpawnTime => spawnTime;

    [SerializeField] private Skill skill;
    public Skill Skill => skill;

    private bool isUse = false;
    public bool IsUse => isUse;
    //Singleton
    private static UltimateSkillSpawner instance;
    public static UltimateSkillSpawner Instance => instance;
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
        string path = "Skills/UltimateSkill/" + skillOne;
        Debug.Log(path);
        skill = Resources.Load<Skill>(path);
    }
    private void Start()
    {
        ultimateSkillPool = new ObjectPool(this.GetPrefabByName(skillOne), pool, 25, 100);
    }
    public IEnumerator SpawnUltimateSkill(int count, float spawnRadius)
    {
        Vector2 randomOffset;
        Vector3 strikePos;
        Vector3 spawnPosition = InputManager.Instance.MouseWorldPos;
        spawnPosition.z = 0;
        for (int i = 0; i < count; i++)
        {
            randomOffset = Random.insideUnitCircle * spawnRadius;
            strikePos = spawnPosition + (Vector3)randomOffset;
            spawnPoint = spawnFromPlayer;
            spawnTime = Time.time;
            SpawnObject(ultimateSkillPool, strikePos, Quaternion.identity);
            AudioManager.Instance.SoundAudio.PlayOneShot(AudioManager.Instance.lightningSound);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void RemoveDashSkill(Transform _object)
    {
        RemoveObject(ultimateSkillPool, _object);
    }
}

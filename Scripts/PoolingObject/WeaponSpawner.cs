using UnityEngine;
using UnityEngine.Pool;

public class WeaponSpawner : Spawner
{
    private string skillOne = "SwordThrow";
    protected ObjectPool weaponPool;
    private Vector3 spawnPoint = Vector3.zero;
    public Vector3 SpawnPoint => spawnPoint;

    [SerializeField] private Skill skill;
    public Skill Skill => skill;
    //Singleton
    private static WeaponSpawner instance;
    public static WeaponSpawner Instance => instance;
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
        string path = "Skills/NormalAttackSkill/" + skillOne;
        skill = Resources.Load<Skill>(path);
    }
    private void Start()
    {
        weaponPool = new ObjectPool(this.GetPrefabByName(skillOne), pool, 25, 100);
    }
    private Transform SpawnWeapon(Vector3 spawnPos, Quaternion spawnRot)
    {
        spawnPoint = spawnPos;
        return SpawnObject(weaponPool, spawnPos, spawnRot);
    }
    public void RemoveWeapon(Transform _object)
    {
        RemoveObject(weaponPool, _object);
    }
    public override void SpawnFromPlayerToMouse()
    {
        base.SpawnFromPlayerToMouse();
        Transform newObject = SpawnWeapon(spawnFromPlayer, spawnRot);
    }
}

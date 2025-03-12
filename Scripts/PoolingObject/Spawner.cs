using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform pool;
    protected Vector3 targetPosition;
    protected Vector3 spawnFromPlayer;
    protected Quaternion spawnRot;

    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;
    protected virtual void Reset()
    {
        this.LoadPool();
        this.LoadPrefabs();
    }
    protected virtual void LoadPool()
    {
        if (this.pool != null) return;
        this.pool = transform.Find("Pool");
        Debug.Log(transform.name + ": LoadPool", gameObject);
    }
    public void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }
    private void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
    protected virtual Transform SpawnObject(ObjectPool objectPool, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newObject = objectPool.GetObject(spawnPos, spawnRot);
        return newObject;
    }
    protected void RemoveObject(ObjectPool objectPool, Transform _object)
    {
        objectPool.ReleaseObject(_object);
    }
    public virtual void SpawnFromPlayerToMouse()
    {
        spawnFromPlayer = GameCtrl.Instance.PlayerCtrl.transform.position;
        this.GetTargetPosition();
        Vector2 direction = (this.targetPosition - spawnFromPlayer).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spawnRot = Quaternion.Euler(new Vector3(0, 0, angle));
        //Transform newObject = SpawnObject(spawnPos, spawnRot);
        //if (newBullet == null) return;
    }
    public virtual void SpawnFromEnemyToPlayer(string enemySkillName, Vector3 spawnPosition)
    {
        Vector3 playerPos = GameCtrl.Instance.PlayerCtrl.transform.position;
        Vector2 direction = (playerPos - spawnPosition).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spawnRot = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
    public virtual Transform RandomPrefabs()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
}

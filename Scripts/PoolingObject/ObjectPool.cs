using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool
{
    Transform prefab;
    Transform Pool;
    ObjectPool<Transform> pool;
    int defaultSize;
    int maxSize;

    public Transform Prefab => prefab;
    public ObjectPool(Transform prefab, Transform poolParent, int defaultSize = 20, int maxSize = 100)
    {
        this.prefab = prefab;
        this.Pool = poolParent; 

        this.defaultSize = defaultSize;
        this.maxSize = maxSize;
        pool = new ObjectPool<Transform>(
            CreatePooledObject,
            OnGetFromPool,
            OnReturnToPool,
            OnDestroyPooledObject,
            true,
            defaultSize,
            maxSize
            );
    }

    public Transform GetObject(Vector3 position, Quaternion rotation)
    {
        Transform obj = pool.Get();
        obj.position = position;
        obj.rotation = rotation;
        //if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
        //{
        //    rb.velocity = Vector3.zero;
        //    rb.angularVelocity = Vector3.zero;
        //}
        return obj;
    }

    public void ReleaseObject(Transform obj)
    {
        pool.Release(obj);
    }

    Transform CreatePooledObject()
    {
        Transform newObject = Object.Instantiate(prefab);
        newObject.name = prefab.name;
        newObject.parent = Pool;
        return newObject;
    }

    void OnGetFromPool(Transform pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    void OnReturnToPool(Transform pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    void OnDestroyPooledObject(Transform pooledObject)
    {
        GameObject.Destroy(pooledObject.gameObject);
    }
    public int GetAvailableCount()
    {
        return pool.CountInactive;
    }
}

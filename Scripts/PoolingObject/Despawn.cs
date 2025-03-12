using UnityEngine;
public class Despawn : MonoBehaviour
{
    [SerializeField] protected float attackRange = 4f;
    [SerializeField] protected float maintainTime = 2f;
    protected virtual void Update()
    {
        //
    }
    protected virtual void Reset()
    {
        //
    }
    protected void DespawnObjectByDistance(Vector3 spawnPoint)
    {
        float distance = Vector3.Distance(transform.position, spawnPoint);
        if (distance < attackRange) return;
        DespawnObject();
    }
    protected void DespawnObjectByTime(float time)
    {
        if (time + maintainTime > Time.time) return;
        DespawnObject();
    }
    protected virtual void DespawnObject()
    {
        //
    }
    protected virtual void DespawnObject(string objectName)
    {
        //
    }
}

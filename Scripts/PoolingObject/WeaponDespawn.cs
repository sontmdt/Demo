using UnityEngine;

public class WeaponDespawn : Despawn
{
    protected override void Reset()
    {
        attackRange = 4f;
    }

    protected override void Update()
    {
        this.DespawnObjectByDistance(WeaponSpawner.Instance.SpawnPoint);
    }
    protected override void DespawnObject()
    {
        WeaponSpawner.Instance.RemoveWeapon(transform.parent);
    }
}

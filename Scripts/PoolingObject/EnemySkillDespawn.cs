using UnityEngine;
public class EnemySkillDespawn : Despawn
{
    protected override void Reset()
    {
        attackRange = 10f;
    }
    protected override void Update()
    {
        this.DespawnObjectByDistance(EnemySkillSpawner.Instance.SpawnPoint);
    }
    protected override void DespawnObject()
    {
        EnemySkillSpawner.Instance.RemoveBasicSkill(transform.parent);
    }

}

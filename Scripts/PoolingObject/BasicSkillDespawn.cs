using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkillDespawn : Despawn
{
    protected override void Reset()
    {
        attackRange = 10f;
    }
    protected override void Update()
    {
        this.DespawnObjectByDistance(BasicSkillSpawner.Instance.SpawnPoint);
    }
    protected override void DespawnObject()
    {
        BasicSkillSpawner.Instance.RemoveBasicSkill(transform.parent);
    }
}

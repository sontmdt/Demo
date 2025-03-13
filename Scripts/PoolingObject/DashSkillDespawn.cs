using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkillDespawn : Despawn
{
    protected override void Reset()
    {
        maintainTime = 2f;
    }
    protected override void Update()
    {
        this.DespawnObjectByTime(DashSkillSpawner.Instance.SpawnTime);
    }
    protected override void DespawnObject()
    {
        DashSkillSpawner.Instance.RemoveDashSkill(transform.parent);
    }
}

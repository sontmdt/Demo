using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSkillDespawn : Despawn
{
    protected override void Reset()
    {
        maintainTime = 1f;
    }
    protected override void Update()
    {
        this.DespawnObjectByTime(UltimateSkillSpawner.Instance.SpawnTime);
    }
    protected override void DespawnObject()
    {
        UltimateSkillSpawner.Instance.RemoveDashSkill(transform.parent);
    }
}

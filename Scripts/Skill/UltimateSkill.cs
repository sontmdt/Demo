using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class UltimateSkill : ISkill
{
    public float lastUsedTime { get; set; } = -Mathf.Infinity;
    public float coolDown => UltimateSkillSpawner.Instance.Skill.coolDown;
    //public float coolDown => 10f;

    private float spawnRadius = 3f;
    private int count = 100;
    public void UseSkill()
    {
        UltimateSkillSpawner.Instance.StartCoroutine(UltimateSkillSpawner.Instance.SpawnUltimateSkill(count, spawnRadius));

        lastUsedTime = Time.time;
    }
    public bool CanUseSkill()
    {
        return Time.time >= lastUsedTime + coolDown && GameCtrl.Instance.PlayerCtrl.PlayerAttribute.UseMana(BasicSkillSpawner.Instance.Skill.mana);
    }
}

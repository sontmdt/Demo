using UnityEngine;
public class EnemyBasicSkill : ISkill
{
    public string name;
    public float lastUsedTime { get; set; } = -Mathf.Infinity;
    //public float coolDown => EnemySkillSpawner.Instance.Skill.FirstOrDefault(s => s.name == name).coolDown;
    public float coolDown
    {
        get
        {
            Skill foundSkill = EnemySkillSpawner.Instance.Skill.Find(s => s.name == name);
            return foundSkill != null ? foundSkill.coolDown : 0f;
        }
    }

    //public float coolDown => 1f;
    public void UseSkill()
    {
        //
    }
    public virtual void UseSkill(string skillName, Vector3 spawnPos)
    {
        name = skillName;
        EnemySkillSpawner.Instance.SpawnFromEnemyToPlayer(skillName, spawnPos);
        lastUsedTime = Time.time;
    }
    public bool CanUseSkill()
    {
        return Time.time >= lastUsedTime + coolDown;
    }
}

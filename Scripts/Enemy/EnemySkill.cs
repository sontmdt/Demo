using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    private SkillManager skill;
    private EnemyBasicSkill enemyBasicSkill;
    [SerializeField] protected string skillName;
    private void Start()
    {
        skill = gameObject.AddComponent<SkillManager>();
        enemyBasicSkill = new EnemyBasicSkill();
        skill.SetSkill(enemyBasicSkill);
    }
    public void Attack()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.z = 0;
        skill.PerformAttack(skillName, spawnPos);
    }
    public bool checkCoolDown()
    {
        return skill.currentSkill.CanUseSkill();
    }
}

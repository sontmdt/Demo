using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public ISkill currentSkill;
    public void SetSkill(ISkill skill)
    {
        currentSkill = skill;
    }
    public void PerformAttack()
    {
        if (currentSkill == null) return;
        if (!currentSkill.CanUseSkill()) return;
        currentSkill.UseSkill();
    }
    public void PerformAttack(string skillName, Vector3 spawnPos)
    {
        if (currentSkill == null) return;
        if (!currentSkill.CanUseSkill()) return;
        currentSkill.UseSkill(skillName, spawnPos);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]

public class Skill : ScriptableObject
{
    public SkillCode skillCode = SkillCode.NoSkill;
    public SkillType skillType = SkillType.NoType;

    public float damage = 0;
    public float mana = 0;
    //public Sprite skillItem;
    public float coolDown = 0;
    public int currentLevel = 1;

    public virtual Skill Clone()
    {
        Skill skill = new Skill
        {
            skillCode = this.skillCode,
            skillType = this.skillType,
            damage = this.damage,
            mana = this.mana,
            coolDown = this.coolDown,
            currentLevel = this.currentLevel,
        };
        return skill;
    }

}

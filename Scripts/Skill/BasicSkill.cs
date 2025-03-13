using UnityEngine;
public class BasicSkill : ISkill
{
    public float lastUsedTime { get; set; } = -Mathf.Infinity;
    public float coolDown => BasicSkillSpawner.Instance.Skill.coolDown;
    //public float coolDown => 1f;
    public void UseSkill()
    {
        BasicSkillSpawner.Instance.SpawnFromPlayerToMouse();
        AudioManager.Instance.SoundAudio.PlayOneShot(AudioManager.Instance.fireBallSound);
        lastUsedTime = Time.time;
    }
    public bool CanUseSkill()
    {
        return Time.time >= lastUsedTime + coolDown && GameCtrl.Instance.PlayerCtrl.PlayerAttribute.UseMana(BasicSkillSpawner.Instance.Skill.mana);
    }
}

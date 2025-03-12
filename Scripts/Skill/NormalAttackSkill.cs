using UnityEngine;

public class NormalAttackSkill : ISkill
{
    public float lastUsedTime { get; set; } = -Mathf.Infinity;
    public float coolDown => WeaponSpawner.Instance.Skill.coolDown; 
    public void UseSkill()
    {
        WeaponSpawner.Instance.SpawnFromPlayerToMouse();
        AudioManager.Instance.SoundAudio.PlayOneShot(AudioManager.Instance.attackSound);
        lastUsedTime = Time.time;
    }
    public bool CanUseSkill()
    {
        return Time.time >= lastUsedTime + coolDown;
    }
}

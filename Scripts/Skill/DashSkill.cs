using UnityEngine;
public class DashSkill : ISkill
{
    public float lastUsedTime { get; set; } = -Mathf.Infinity;
    public float coolDown => DashSkillSpawner.Instance.Skill.coolDown;

    public float maxDistace = 3f;
    public float moveSpeed = 100f;
    public void UseSkill()
    {
        Vector3 dashDirection = InputManager.Instance.MouseWorldPos;
        dashDirection.z = 0f;
        Vector3 playerPosition = GameCtrl.Instance.PlayerCtrl.transform.position;
        float distance = (dashDirection - playerPosition).magnitude;

        Vector2 movement = InputManager.Instance.Movement;
        DashSkillSpawner.Instance.SpawnDashSkill(playerPosition, Quaternion.identity);
        if (distance > maxDistace)
        {
            Vector3 dashPosition = playerPosition + (dashDirection - playerPosition) * maxDistace/distance;
            GameCtrl.Instance.PlayerCtrl.transform.position = Vector3.Lerp(playerPosition, dashPosition, moveSpeed * Time.deltaTime);
            DashSkillSpawner.Instance.SpawnDashSkill(dashPosition, Quaternion.identity);
        }
        else
        {
            GameCtrl.Instance.PlayerCtrl.transform.position = Vector3.Lerp(playerPosition, dashDirection, moveSpeed * Time.deltaTime);
            playerPosition = GameCtrl.Instance.PlayerCtrl.transform.position;
            DashSkillSpawner.Instance.SpawnDashSkill(playerPosition, Quaternion.identity);
        }
        AudioManager.Instance.SoundAudio.PlayOneShot(AudioManager.Instance.dashSound);
        lastUsedTime = Time.time;
    }
    public bool CanUseSkill()
    {
        return Time.time >= lastUsedTime + coolDown && GameCtrl.Instance.PlayerCtrl.PlayerAttribute.UseMana(BasicSkillSpawner.Instance.Skill.mana);
    }
}

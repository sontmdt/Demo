using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private SkillManager player;
    private NormalAttackSkill normalAttackSkill;
    public NormalAttackSkill NormalAttackSkill => normalAttackSkill;

    private BasicSkill basicSkill;
    public BasicSkill BasicSkill => basicSkill;

    private DashSkill dashSkill;
    public DashSkill DashSkill => dashSkill;

    private UltimateSkill ultimateSkill;
    public UltimateSkill UltimateSkill => ultimateSkill;

    private void Start()
    {
        player = gameObject.AddComponent<SkillManager>();
        normalAttackSkill = new NormalAttackSkill();
        basicSkill = new BasicSkill();
        dashSkill = new DashSkill();
        ultimateSkill = new UltimateSkill();
    }
    private void Update()
    {
        this.Attack();
    }
    private void Attack()
    {
        if (InputManager.Instance.UseNormalAttackSkill)
        {
            player.SetSkill(normalAttackSkill);
            player.PerformAttack();
        }
        if (InputManager.Instance.UseBasicSkill)
        {
            player.SetSkill(basicSkill);
            player.PerformAttack();
        }
        if (InputManager.Instance.UseDashSkill)
        {
            player.SetSkill(dashSkill);
            player.PerformAttack();
        }
        if (InputManager.Instance.UseUltimateSkill)
        {
            player.SetSkill(ultimateSkill);
            player.PerformAttack();
        }
    }
}

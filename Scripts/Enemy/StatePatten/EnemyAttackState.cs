using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private bool isAttacking = false;
    public void EnterState(Enemy enemy)
    {
        enemy.agent.ResetPath();
        enemy.animator.Play("Attack");
        enemy.EnemyCtrl.EnemySkill.Attack();
        isAttacking = true;
    }

    public void UpdateState(Enemy enemy)
    {
        AnimatorStateInfo stateInfo = enemy.animator.GetCurrentAnimatorStateInfo(0);
        if (isAttacking && stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 1.0f)
        {
            isAttacking = false;
            enemy.ChangeState(enemy.chaseState);
        }
    }

    public void ExitState(Enemy enemy)
    {
    }
}

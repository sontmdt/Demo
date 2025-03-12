using TMPro;
using UnityEngine;
public class EnemyChaseState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        enemy.animator.Play("Chase");
    }
    public void UpdateState(Enemy enemy)
    {
        if (enemy.AttackRange() && enemy.EnemyCtrl.EnemySkill.checkCoolDown() == true) enemy.ChangeState(enemy.attackState);
        else if (!enemy.ChaseRange()) enemy.ChangeState(enemy.moveState);
        enemy.agent.speed = 2;
        //Vector3 playerPosition = GameCtrl.Instance.PlayerCtrl.transform.position;
        //Vector3 targetPosition = playerPosition;
        //if (playerPosition.x < enemy.transform.position.x) targetPosition.x = playerPosition.x + enemy.DistanceMin;
        //else targetPosition.x = playerPosition.x - enemy.DistanceMin;
        //enemy.agent.SetDestination(targetPosition);
        Vector3 playerPos = GameCtrl.Instance.PlayerCtrl.transform.position;
        float stopDistance = enemy.AttackDistance - enemy.DistanceMin;
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, playerPos);

        if (distanceToPlayer > stopDistance)
        {
            Vector3 direction = (playerPos - enemy.transform.position).normalized;
            Vector3 targetPosition = playerPos - direction * stopDistance;
            enemy.agent.SetDestination(targetPosition);
        }
    }
    public void ExitState(Enemy enemy)
    {
    }
}

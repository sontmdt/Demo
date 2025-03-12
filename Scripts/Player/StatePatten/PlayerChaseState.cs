using UnityEngine;
using UnityEngine.AI;
public class PlayerChaseState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Bat dau theo");
    }
    public void UpdateState(Enemy enemy)
    {
        if (enemy.AttackRange()) enemy.ChangeState(enemy.attackState);
        else if (!enemy.ChaseRange()) enemy.ChangeState(enemy.moveState);
        enemy.agent.speed = 2;
        enemy.agent.SetDestination(GameCtrl.Instance.PlayerCtrl.transform.position);
    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("Ket thuc theo");
    }
}

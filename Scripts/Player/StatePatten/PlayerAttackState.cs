using UnityEngine;
public class PlayerAttackState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Bat dau tan cong");
    }
    public void UpdateState(Enemy enemy)
    {
        if (!enemy.AttackRange()) enemy.ChangeState(enemy.chaseState);
    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("Ket thuc tan cong");
    }
}

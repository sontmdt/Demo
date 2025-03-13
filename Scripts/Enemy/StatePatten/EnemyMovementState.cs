using System.Collections.Generic;
using UnityEngine;
public class EnemyMovementState : IEnemyState
{
    private List<Vector3> waypoints = new List<Vector3>();
    //private int currentWaypointIndex = 0;
    public void EnterState(Enemy enemy)
    {
        enemy.agent.isStopped = false;
        enemy.animator.Play("Move");
    }
    public void UpdateState(Enemy enemy)
    {
        if (enemy.ChaseRange()) enemy.ChangeState(enemy.chaseState);
        enemy.agent.speed = 1;
        enemy.agent.SetDestination(GameCtrl.Instance.PlayerCtrl.transform.position);

    }
    public void ExitState(Enemy enemy)
    {
    }
    //private void SetNewDestination(Enemy enemy)
    //{
    //    enemy.agent.SetDestination(waypoints[currentWaypointIndex]);
    //}
    //private void SetNextDestination(Enemy enemy)
    //{
    //    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
    //    SetNewDestination(enemy);
    //}
}

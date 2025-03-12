using System.Collections.Generic;
using UnityEngine;
public class PlayerMovementState : IEnemyState
{
    private List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypointIndex = 0;
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Bat dau di chuyen");
        enemy.agent.isStopped = false;

        waypoints.Add(new Vector3(0f, 0f, 10f));  
        waypoints.Add(new Vector3(10f, 0f, 10f)); 
        waypoints.Add(new Vector3(10f, 0f, 0f));  
        waypoints.Add(new Vector3(0f, 0f, 0f));
    }
    public void UpdateState(Enemy enemy)
    {
        if (enemy.ChaseRange()) enemy.ChangeState(enemy.chaseState);
        enemy.agent.speed = 1;
        enemy.agent.SetDestination(GameCtrl.Instance.PlayerCtrl.transform.position);

    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("Ket thuc di chuyen");
    }
    private void SetNewDestination(Enemy enemy)
    {
        enemy.agent.SetDestination(waypoints[currentWaypointIndex]);
    }
    private void SetNextDestination(Enemy enemy)
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        SetNewDestination(enemy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Bat dau chet");
    }
    public void UpdateState(Enemy enemy)
    {
        //
    }
    public void ExitState(Enemy enemy)
    {
        Debug.Log("Ket thuc chet");
    }
}

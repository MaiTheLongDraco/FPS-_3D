using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChaseState : IEnemyState
{
    public void EnterState(Enemy _ctx)
    {
        Debug.Log("enter chase state");
        _ctx.States = Enemy.State.CHASE_STATE;

    }

    public void ExitState(Enemy _ctx)
    {
        Debug.Log("exit chase state");
    }

    public void UpdateState(Enemy _ctx)
    {
        Debug.Log("update chase state");
    }
}

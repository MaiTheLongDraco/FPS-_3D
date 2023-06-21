using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_IdleState :IEnemyState
{
    public void EnterState(Enemy _ctx)
    {
        _ctx.Animator.SetBool("isRunning", false);
        _ctx.States = Enemy.State.IDLE_STATE;
        Debug.Log("enter idle state");
    }

    public void ExitState(Enemy _ctx)
    {
        Debug.Log("exit idle state");

    }



    public void UpdateState(Enemy _ctx)
    {
        Debug.Log("update idle state");

    }
}

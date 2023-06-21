using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DeathState : IEnemyState
{
    public void EnterState(Enemy _ctx)
    {
        Debug.Log("enter death state");
        _ctx.States = Enemy.State.DEATH_STATE;
        _ctx.gameObject.SetActive(false);

    }

    public void ExitState(Enemy _ctx)
    {
        Debug.Log("exit death state");
    }


    public void UpdateState(Enemy _ctx)
    {
        Debug.Log("update death state");
    }
}

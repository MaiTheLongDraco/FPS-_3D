using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AttackState : IEnemyState
{
    public void EnterState(Enemy _ctx)
    {
        Debug.Log("enter attack state");
        _ctx.States = Enemy.State.ATTACK_STATE;
        _ctx.Animator.SetBool("isShooting", true);

    }

    public void ExitState(Enemy _ctx)
    {
       var gun= _ctx.GetComponentInChildren<EnemyGun>();

        if(gun)
        gun.impactPrefab.Stop();
        Debug.Log("enter exit atk state");


    }


    public void UpdateState(Enemy _ctx)
    {
        var gun = _ctx.GetComponentInChildren<EnemyGun>();
        Debug.Log(_ctx.IsPlayerInRange+ "_ctx.IsPlayerInRange");
        if (gun&&_ctx.IsPlayerInRange)
        {
            gun.DelayShooting();
        }
        if(!_ctx.IsPlayerInRange)
        {
            ExitState(_ctx);
            Debug.Log("enter player in range check");
        }
        Debug.Log("update attack state");

    }
}

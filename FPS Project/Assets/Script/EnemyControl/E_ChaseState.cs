using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class E_ChaseState : IEnemyState
{
    public void EnterState(Enemy _ctx)
    {
        _ctx.Animator.SetBool("isRunning", true);
        //_ctx.IsPlayerInRange= true;
        //  _ctx.SetIsPlayerOnRange(true);
        Debug.Log("enter chase state");
        _ctx.States = Enemy.State.CHASE_STATE;
    }

    public void ExitState(Enemy _ctx)
    {
        _ctx.Animator.SetBool("isRunning", false);
        Debug.Log("exit chase state");
    }

    public void UpdateState(Enemy _ctx)
    {
        var player = _ctx.PlayerTranform.position;
        var dir = player - _ctx.transform.position;
        _ctx.FinalStandPos = player - dir;
        Debug.Log("update chase state");
        if (_ctx.IsPlayerInRange)
        {
            _ctx.NavMesh.SetDestination(player);
            HandlPlayerInATK(_ctx);
            // Debug.Log(_ctx.IsPlayerInRange + "_ctx.IsPlayerInRange inside");
        }
        else
        {
            ExitState(_ctx);
            _ctx.SetState(_ctx._runsate);
        }
    }
    private void HandlPlayerInATK(Enemy _ctx)
    {
        var playerTranform = _ctx.PlayerTranform.position;
        if (Vector3.Distance(_ctx.transform.position, playerTranform) <= _ctx.DetectRange / 8)
        {
            _ctx.SetState(_ctx._attackState);
        }
    }
}

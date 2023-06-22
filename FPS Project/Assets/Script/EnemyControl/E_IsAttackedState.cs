using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class E_IsAttackedState : IEnemyState
{
    public void EnterState(Enemy _ctx)
    {
        _ctx.Animator.SetBool("isRunning", true);
        //_ctx.IsPlayerInRange= true;
      //  _ctx.SetIsPlayerOnRange(true);
        Debug.Log("enter isAttacked state");
        _ctx.States = Enemy.State.ISATTACKED_STATE;
    }

    public void ExitState(Enemy _ctx)
    {
        _ctx.Animator.SetBool("isRunning", false);
        Debug.Log("exit isATK state");
    }

    public void UpdateState(Enemy _ctx)
    {
        var player = _ctx.PlayerTranform.position;
        Debug.Log("update isAtk state");
        _ctx.NavMesh.SetDestination(player);
        CheckPlayer(_ctx);
        if (_ctx.IsPlayerInRange)
        {
            HandlPlayerInATK(_ctx);
        }
       
    }
    private void HandlPlayerInATK(Enemy _ctx)
    { 
        var playerTranform = _ctx.PlayerTranform.position;
        if(Vector3.Distance(_ctx.transform.position, playerTranform)<=_ctx.DetectRange/2)
        {
            _ctx.SetState(_ctx._attackState);
            Debug.Log("Player in range");
        }
    }
    private bool CheckPlayer(Enemy _ctx)
    {
        var playerTranform = _ctx.PlayerTranform.position;
        if (Vector3.Distance(_ctx.transform.position, playerTranform) <= _ctx.DetectRange )
        {
            _ctx.IsPlayerInRange = true;
        }
        return _ctx.IsPlayerInRange;
    }
}

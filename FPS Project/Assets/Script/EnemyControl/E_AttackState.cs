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
        _ctx.NavMesh.SetDestination(_ctx.transform.position);
    }

    public void ExitState(Enemy _ctx)
    {
        var gun = _ctx.GetComponentInChildren<EnemyGun>();
        _ctx.Animator.SetBool("isShooting", false);
        if (gun)
            gun.impactPrefab.Stop();
        Debug.Log(" exit atk state----");
    }


    public void UpdateState(Enemy _ctx)
    {
        var gun = _ctx.GetComponentInChildren<EnemyGun>();
        var player = _ctx.PlayerTranform.position;
        Debug.Log(_ctx.IsPlayerInRange + "_ctx.IsPlayerInRange");
        if (gun && _ctx.IsPlayerInRange)
        {
            RaycastHit hit;
            var dir = _ctx.PlayerTranform.transform.position - _ctx.transform.position;
            var isHitObject = Physics.Raycast(_ctx.transform.position, dir, out hit, 300);
            if (isHitObject)
            {
                var notHitRightObject = hit.transform.gameObject.layer != LayerMask.NameToLayer("Player");
                Debug.Log($"notHitRightObject---- {notHitRightObject}");
                if (notHitRightObject)
                {
                    ExitState(_ctx);
                    _ctx.SetState(_ctx._chaseState);
                }
                else
                {
                    gun.DelayShooting();
                    _ctx.transform.LookAt(player);
                }
            }
            if (Vector3.Distance(_ctx.transform.position, player) > _ctx.DetectRange) _ctx.IsPlayerInRange = false;
        }
        if (!_ctx.IsPlayerInRange)
        {
            ExitState(_ctx);
            _ctx.SetState(_ctx._runsate);
            Debug.Log("enter player in range check");
        }
        Debug.Log("update attack state");

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class E_RunState : IEnemyState
{
    private Vector3 _roamingPos;
    private bool _isRoaming;
    private float roamDelay = 2f;
    private float roamTimer;
    public void EnterState(Enemy _ctx)
    {
        Debug.Log("enter run state");
        _ctx.Animator.SetBool("isRunning", true);
        _ctx.Animator.SetBool("isShooting", false);
        _ctx.States = Enemy.State.RUN_STATE;
        _roamingPos = _ctx.transform.position;
        _isRoaming = true;
        Debug.LogError(_isRoaming + "_isRoaming");
        //  _ctx.IsPlayerInRange = false;
        var gun = _ctx.GetComponentInChildren<EnemyGun>();
        gun.impactPrefab.Stop();
    }

    public void ExitState(Enemy _ctx)
    {
        _ctx.PlaySound();
        _ctx.Animator.SetBool("isRunning", false);
        Debug.Log("exit run state");

    }

    public Vector3 GetRoamingPos(Vector3 _enemyPos)
    {
        Vector2 randomCircle = Random.insideUnitCircle * Random.Range(10f, 50f);
        Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return _enemyPos + randomPosition;
    }
    public void CheckPlayerInAtkRange(Enemy _ctx)
    {
        Collider[] _col = Physics.OverlapSphere(_ctx.transform.position, _ctx.DetectRange);
        foreach (var sample in _col)
        {
            if (sample.CompareTag("Player"))
            {
                _ctx.IsPlayerInRange = true;
                Debug.Log("collie with Player");

            }

        }
    }
    private void HandlePlayerInRange(Enemy _ctx)
    {
        if (_ctx.IsPlayerInRange)
        {
            ExitState(_ctx);
            _ctx.SetState(_ctx._chaseState);
        }

    }

    public void UpdateState(Enemy _ctx)
    {

        //Debug.LogError(_isRoaming + "_isRoaming");
        DoRoaming(_ctx);
        CheckPlayerInAtkRange(_ctx);
        HandlePlayerInRange(_ctx);
    }

    private void DoRoaming(Enemy _ctx)
    {
        var enemyPos = _ctx.transform.position;
        if (_isRoaming)
        {
            _ctx.NavMesh.SetDestination(_roamingPos);
            if (Vector3.Distance(enemyPos, _roamingPos) < 5f)
            {
                _ctx.Animator.SetBool("isRunning", false);
                Debug.Log($"do roaming {_isRoaming}");
                roamTimer = 0;
                _isRoaming = false;
            }
        }
        else
        {
            roamTimer += Time.deltaTime;
            if (roamTimer >= roamDelay)
            {
                Debug.Log($"!do roaming {_isRoaming}");

                _ctx.Animator.SetBool("isRunning", true);
                _roamingPos = GetRoamingPos(enemyPos);
                Vector3 direction = _roamingPos - enemyPos;
                _ctx.transform.LookAt(direction.normalized);
                Debug.DrawLine(enemyPos, direction);
                var check = IsRoamingPosValid(_roamingPos, enemyPos);
                if (!check)
                {
                    NavMeshHit hit;
                    _roamingPos = GetRoamingPos(enemyPos);
                    if (NavMesh.SamplePosition(_roamingPos, out hit, 0.1f, NavMesh.AllAreas))
                    {
                        _roamingPos = hit.position;
                    }
                    else
                    {
                        _roamingPos = _ctx.transform.position;
                    }

                }
                Debug.Log("Come to next roam");
                _isRoaming = true;

            }
        }
    }
    private bool IsRoamingPosValid(Vector3 roamingPos, Vector3 enemyPos)
    {
        NavMeshHit hit;
        var dir = roamingPos - enemyPos;
        bool isOnNavMesh = NavMesh.SamplePosition(_roamingPos, out hit, 0.1f, NavMesh.AllAreas);
        if (!isOnNavMesh)
        {
            Debug.Log($"not on navmesh -----");
            return false;
        }
        else
        {
            var hitBulding = Physics.Raycast(enemyPos, dir, dir.magnitude, LayerMask.NameToLayer("Building"));
            if (hitBulding)
            {
                Debug.Log($"hit building -----");
                return false;
            }
            else
            {
                Debug.Log($"not hit building-----");
                return true;
            }
        }
    }

}

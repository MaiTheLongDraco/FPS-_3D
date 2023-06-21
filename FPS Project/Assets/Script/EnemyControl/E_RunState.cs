using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RunState : IEnemyState
{
    private Vector3 _roamingPos;
    private bool _isRoaming;
    private float roamDelay=3f;
    private float roamTimer;
    public void EnterState(Enemy _ctx)
    {
        Debug.Log("enter run state");
        _ctx.Animator.SetBool("isRunning", true);
        _ctx.Animator.SetBool("isShooting", false);
        _ctx.States = Enemy.State.RUN_STATE;
        _roamingPos = _ctx.transform.position;
        _isRoaming=true;
      //  _ctx.IsPlayerInRange = false;
       var gun =_ctx.GetComponentInChildren<EnemyGun>();
        gun.impactPrefab.Stop();
    }

    public void ExitState(Enemy _ctx)
    {
        _ctx.Animator.SetBool("isRunning", false);
        Debug.Log("exit run state");

    }

    public Vector3 GetRoamingPos(Vector3 _enemyPos)
    {
        Vector2 randomCircle = Random.insideUnitCircle * Random.Range(10f,50f);
        Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return _enemyPos + randomPosition;
    }

    public void UpdateState(Enemy _ctx)
    {
        var enemyPos = _ctx.transform.position;

        if (_isRoaming)
        {
          
            _ctx.transform.position = Vector3.MoveTowards(enemyPos, _roamingPos, _ctx.Speed * Time.deltaTime);
            if (Vector3.Distance(enemyPos, _roamingPos) < 0.2f)
            {
                roamTimer = 0;
                _isRoaming = false;
            _ctx.Animator.SetBool("isRunning", false);
            }

        }
        else
        {
            roamTimer += Time.deltaTime;
            if(roamTimer>=roamDelay)
            {
                _isRoaming = true;
                _ctx.Animator.SetBool("isRunning", true);
                _roamingPos = GetRoamingPos(enemyPos);
                Vector3 direction = _roamingPos - enemyPos;
                _ctx.transform.LookAt(direction.normalized);
                Debug.Log("Come to next roam");
            }
        }
       
      //  Debug.DrawRay(_ctx.transform.position, direction, Color.red);
       
    }
}

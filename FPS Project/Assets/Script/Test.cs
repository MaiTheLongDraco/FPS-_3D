using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform PosToFollow;
    private Enemy _enemy;
    private void Awake()
    {
        _enemy=GetComponent<Enemy>();
    }
    private void FollowPos()
    {
        Agent.SetDestination(PosToFollow.position);
    }
    private void Update()
    {
        CheckPlayerInRange();
    }
    private void CheckPlayerInRange()
    {
        var inRange = _enemy.IsPlayerInRange;
        if(inRange)
        {
            FollowPos();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_IdleState :IEnemyState
{
    public void Handle()
    {
        //_animator.SetBool("isRunning", false);
        Debug.Log("In Idle State");
    }
}

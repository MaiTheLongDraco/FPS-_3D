using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DeathState : IEnemyState
{
    public void Handle()
    {
        Debug.Log("Is In Death State");
    }
}

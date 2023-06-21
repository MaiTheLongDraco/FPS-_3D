using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeath : MonoBehaviour
{
    #region public var
    #endregion
    #region private var
    [SerializeField] private int _heath;
    #endregion
    public void TakeDamage(int damage)
    {
        _heath -= damage;
       
    }
    private void HandleIfDead()
    {
       
        Debug.Log("Player died");
    }
    private void CheckIfDead()
    {
        if (_heath <= 0)
        {
            HandleIfDead();
        }
    }
    private void Update()
    {
        CheckIfDead();
    }
}

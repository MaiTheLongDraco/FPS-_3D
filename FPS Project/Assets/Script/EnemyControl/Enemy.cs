using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float heath;
    [SerializeField] private GameObject _explosionPrefab;
    private IEnemyState _state;
    // Start is called before the first frame update
    void Start()
    {
        SetState(new E_AttackState());
        //SetState(new E_ChaseState());
        //SetState(new E_DeathState());
        //SetState(new E_IdleState());
    }
    public Enemy ()
    {
        _state = new E_IdleState();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetState(IEnemyState newState)
    {
        _state = newState;
        DoState();
    }
    public void DoState()
    {
        _state.Handle();
    }
    
    public Vector3 GetRoamingPos()
    {
        var rand = Random.Range(-1, 1);
        var pos = new Vector3(rand, 0, rand) * Random.Range(10f, 50f);
        return pos;
    }    
    public void TakeDamage(float damage)
    {
        heath -= damage;
        if(heath<=0)
        {
            Debug.Log("explosion");
          var explode=  Instantiate(_explosionPrefab,transform.position,transform.rotation);
            Destroy(explode,2f);
        }
    }
}

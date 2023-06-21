using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        IDLE_STATE,
        RUN_STATE,
        CHASE_STATE,
        ATTACK_STATE,
        DEATH_STATE
    }
    #region CLOSE FOR MODIFICATION
    [Header(" Enenmy handle var")]
    [SerializeField] private float heath;
    [SerializeField] private State state;
    [SerializeField] private float _dectectRange;
    [SerializeField] private NavMeshAgent  e_NavMesh;
    [SerializeField] private Transform  _playerTranform;
    private Vector3 finalStandPos;
    [SerializeField] private GameObject _explosionPrefab;
    private IEnemyState _state;
    #endregion
    [Header(" Concrete State")]
   public  E_AttackState _attackState=new E_AttackState();
   public  E_RunState _runsate=new E_RunState();
   public  E_DeathState _deadState=new E_DeathState();
   public  E_ChaseState _chaseState=new E_ChaseState();
   public  E_IdleState _idleState=new E_IdleState();
    public bool IsPlayerInRange;
    #region OPEN FOR EXTENSION
    public NavMeshAgent NavMesh => e_NavMesh;
    public State States { get { return state; } set { state = value; } }
    public Animator Animator;
    public float DetectRange { get { return _dectectRange; } }
    public Transform PlayerTranform { get { return _playerTranform; } }
    public Vector3 FinalStandPos { get { return finalStandPos; } set { finalStandPos = value; } }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        e_NavMesh = GetComponent<NavMeshAgent>();
        e_NavMesh.speed = 10f;
        IsPlayerInRange = false;
        SetState(_runsate);
        //StartCoroutine("testStateMachine");
    }
    public Enemy ()
    {
        _state = new E_RunState();
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        _state.UpdateState(this);
        HandlePlayerOutRange();
    }
    public void SetState(IEnemyState newState)
    {
        _state = newState;
        newState.EnterState(this);
    }
    private void HandlePlayerOutRange()
    {
        if(Vector3.Distance(transform.position,_playerTranform.position)>_dectectRange)
        {
            SetIsPlayerOnRange(false);
        }
    }    
      
    public void TakeDamage(float damage)
    {
        heath -= damage;
        if(heath<=0)
        {
            Debug.Log("explosion");
            SetState(_deadState);
            var explode = Instantiate(_explosionPrefab, transform.position, transform.rotation);

            Destroy(explode, 2f);
        }
    }
    public IEnumerator testStateMachine()
    {
        SetState(_idleState);
        _state.UpdateState(this);
        _state.ExitState(this);
        yield return new WaitForSeconds(2f);
        SetState(_runsate);
        _state.UpdateState(this);
        _state.ExitState(this);
        yield return new WaitForSeconds(2f);
        SetState(_chaseState);
        _state.UpdateState(this);
        _state.ExitState(this);
        yield return new WaitForSeconds(2f);
        SetState(_attackState);
        _state.UpdateState(this);
        _state.ExitState(this);
        yield return new WaitForSeconds(2f);
        SetState(_deadState);
        _state.UpdateState(this);
        _state.ExitState(this);
        yield return new WaitForSeconds(2f);
    }   
    public void SetIsPlayerOnRange(bool value)
    {
        IsPlayerInRange= value;
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _dectectRange);
    }
}

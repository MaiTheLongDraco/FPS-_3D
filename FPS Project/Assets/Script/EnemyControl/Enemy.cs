using System.Collections;
using System.Collections.Generic;
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
    [Header(" Enenmy handle var")]
    [SerializeField] private float heath;
    [SerializeField] private float speed;
    [SerializeField] private State state;
    [SerializeField] private float _dectectRange;
    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] private Vector3 m_EulerAngleVelocity;
    [SerializeField] private NavMeshAgent  e_NavMesh;
    [SerializeField] private Transform  _playerTranform;
    public bool IsPlayerInRange;
    private Vector3 finalStandPos;
    
    [SerializeField] private GameObject _explosionPrefab;
    private IEnemyState _state;
    [Header(" Concrete State")]
   public  E_AttackState _attackState=new E_AttackState();
   public  E_RunState _runsate=new E_RunState();
   public  E_DeathState _deadState=new E_DeathState();
   public  E_ChaseState _chaseState=new E_ChaseState();
   public  E_IdleState _idleState=new E_IdleState();
    public State States { get { return state; } set { state = value; } }
    public Animator Animator;
    public float Speed { get { return speed; } set { speed = value; } }
    // Start is called before the first frame update
    void Start()
    {
        IsPlayerInRange = false;
        SetState(_runsate);
        m_Rigidbody = GetComponent<Rigidbody>();
        e_NavMesh = GetComponent<NavMeshAgent>();
        //StartCoroutine("testStateMachine");
    }
    public Enemy ()
    {
        _state = new E_IdleState();
    }
    // Update is called once per frame
    void Update()
    {
        CheckPlayerInAtkRange();
    }
    private void FixedUpdate()
    {
        _state.UpdateState(this);
    }
    public void SetState(IEnemyState newState)
    {
        _state = newState;
        newState.EnterState(this);
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
    public void CheckPlayerInAtkRange()
    {
        Collider[] _col = Physics.OverlapSphere(transform.position, _dectectRange);
        foreach(var sample in _col)
        {
            if (sample.CompareTag("Player"))
            {
                IsPlayerInRange = true;
                Debug.Log("collie with Player");
                //var player = sample.GetComponent<Jump>();
                //var dir = player.transform.position - transform.position;
                //var temp = Quaternion.LookRotation(dir);
                //m_EulerAngleVelocity = new Vector3(0, temp.y, temp.z);
                //Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
                //// transform.rotation=Quaternion.Euler(new Vector3(0,temp.y,temp.z));
                //m_Rigidbody.MoveRotation(deltaRotation * m_Rigidbody.rotation);
                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position- new Vector3(5f, 0, 10f), speed * Time.deltaTime);
                //var newPos = transform.position;
                //newPos.y = 0;
                //transform.position = newPos;
                //if (Vector3.Distance(transform.position, player.transform.position) <= _dectectRange/2 )
                //{
                //    finalStandPos = player.transform.position ;
                //    SetState(_attackState);
                //}
                //else
                //{
                //    transform.position = Vector3.MoveTowards(transform.position, finalStandPos, speed * Time.deltaTime);
                //    SetState(_runsate);
                //}
                e_NavMesh.SetDestination(_playerTranform.position);
            }
           
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _dectectRange);
    }
}

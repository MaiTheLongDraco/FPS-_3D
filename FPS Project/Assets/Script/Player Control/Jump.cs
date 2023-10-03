using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radius;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private CharacterController _charControl;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _gravity;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _targetYVel;

    [SerializeField] private bool isJump;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void SetGravityWithDevice()
    {
#if UNITY_EDITOR
        _gravity = 0.3f;
#else
_gravity=1.3f;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        ResetVelocityY();
        if (isJump)
        {
            if (_isGround == false)
            {
                isJump = false;
            }
            else
            {
                Jumping();
            }
        }
        else
        {
            // if (_isGround)
            //     return;
            _velocity.y += _gravity;
            _charControl.Move(_velocity * Time.deltaTime);
        }
    }
    public void Jumping()
    {
        var rbVel = this.GetComponent<Rigidbody>().velocity.y;
        Debug.Log(_isGround + "IS grounded ??" + $"rbvel {rbVel}");
        print("tessssssssssssssssst");
        _velocity.y = _jumpForce;
        _charControl.Move(_velocity * Time.deltaTime);
    }
    public float GetGravity()
    {
        return _gravity;
    }
    public void SetGravity(float set)
    {
        _gravity = set;
    }
    public void JumpPress()
    {
        isJump = true;
    }
    public void JumpBtnRelease()
    {
        isJump = false;
    }

    private void ResetVelocityY()
    {
        _isGround = Physics.CheckSphere(_groundCheck.position, _radius, _groundLayer);
        if (_isGround && _velocity.y < 0)
        {
            _velocity.y = _targetYVel;
        }

    }
    public float GetJumpForce()
    {
        return _jumpForce;
    }
    public void SetJumpForce(float set)
    {
        _jumpForce = set;
    }
    private bool CheckInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            return true;
        }
        else return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, _radius);
    }
}

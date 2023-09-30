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
    [SerializeField] private bool isJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isJump)
        {
            _isGround = Physics.CheckSphere(_groundCheck.position, _radius, _groundLayer);
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
            _velocity.y += _gravity;
            _charControl.Move(_velocity * Time.deltaTime);
        }
    }
    public void Jumping()
    {

        ResetVelocityY();
        var rbVel = this.GetComponent<Rigidbody>().velocity.y;
        Debug.Log(_isGround + "IS grounded ??" + $"rbvel {rbVel}");
        print("tessssssssssssssssst");
        _velocity.y = _jumpForce;
        _charControl.Move(_velocity * Time.deltaTime);
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
        if (_isGround && _velocity.y < 0)
        {
            isJump = false;
            _velocity.y = -2f;
            print($" Y velocity {_velocity.y}");
        }

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

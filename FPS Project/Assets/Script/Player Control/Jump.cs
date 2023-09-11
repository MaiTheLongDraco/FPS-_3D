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
    private bool _isGround;
    [SerializeField] private float _gravity;
    private Vector3 _velocity;
    private bool isJump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isJump)
        {
            Jumping();
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
        _isGround = Physics.CheckSphere(_groundCheck.position, _radius, _groundLayer);
        if (_isGround)
        {
            Debug.Log(_isGround + "IS grounded ??");
            Vector3 jumpDir = new Vector3(0, _jumpForce, 0);
            _charControl.Move(jumpDir * Time.deltaTime);
        }

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
}

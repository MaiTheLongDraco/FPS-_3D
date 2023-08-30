using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Jumping();
    }
    public void Jumping()
    {
        ResetVelocityY();
        _isGround = Physics.CheckSphere(_groundCheck.position, _radius, _groundLayer);
        if (_isGround)
        {
            Debug.Log(_isGround + "IS grounded ??");
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
        }
        _velocity.y += _gravity * Time.deltaTime;
        _charControl.Move(_velocity * Time.deltaTime);
    }

    private void ResetVelocityY()
    {
        if (_isGround && _velocity.y < 0)
        {
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

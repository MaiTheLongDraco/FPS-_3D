using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    [SerializeField] private CharacterController _charControl;
    [SerializeField] private float moveSpeed;
    [SerializeField] private FixedJoystick fixedJoystick;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnValidate() => _charControl = GetComponent<CharacterController>();
    private void Move()
    {
        var hrInput = fixedJoystick.Horizontal;
        var VTInput = fixedJoystick.Vertical;
        Vector3 direction = transform.right * hrInput + transform.forward * VTInput;
        _charControl.SimpleMove(direction * moveSpeed);
    }
}

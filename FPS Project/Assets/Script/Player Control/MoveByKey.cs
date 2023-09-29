using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    [SerializeField] private CharacterController _charControl;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isSpeedUp;
    [SerializeField] private float desireSpeed;

    [SerializeField] private FixedJoystick fixedJoystick;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(fixedJoystick.gameObject);
        fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        print($"joystick name {GameObject.Find("Fixed Joystick").name}");
    }
    private void OnMouseDown()
    {
        // fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }
    private void OnEnable()
    {
        fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        // fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        if (isSpeedUp)
        {
            moveSpeed = desireSpeed;
        }
        else
        {
            moveSpeed = 20;
        }
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
    public void SpeedUp()
    {
        isSpeedUp = true;
    }
    public void BackToNormalSpeed()
    {
        isSpeedUp = false;
    }
}

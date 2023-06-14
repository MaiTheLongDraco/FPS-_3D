using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    [SerializeField] private CharacterController _charControl;
    [SerializeField] private float moveSpeed;
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
    private void OnValidate() => _charControl=GetComponent<CharacterController>();
    private void Move()
    {
        var hrInput = Input.GetAxis("Horizontal");
        var VTInput = Input.GetAxis("Vertical");
        Vector3 direction= transform.right*hrInput+transform.forward*VTInput;
        _charControl.SimpleMove(direction * moveSpeed);
        //Debug.Log(hrInput+ " " + VTInput);
        //Debug.Log($"tranform right +{transform.right}");
        //Debug.Log($"tranform foward +{transform.forward}");
    }
}

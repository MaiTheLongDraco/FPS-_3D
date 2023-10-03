using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpTestData : MonoBehaviour
{
    [SerializeField] private Jump _pLayerJump;
    [SerializeField] private Text jumpTestTxt;
    [SerializeField] private Text targetVel;

    // Start is called before the first frame update
    void Start()
    {
        SetJump(_pLayerJump.GetJumpForce().ToString());
    }
    private void OnEnable()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetUp()
    {
        _pLayerJump = FindObjectOfType<Jump>();
        SetJump(_pLayerJump.GetJumpForce().ToString());
        SetTargetGravityTxt(_pLayerJump.GetGravity().ToString());
    }
    private void SetJump(string jump)
    {
        jumpTestTxt.text = jump;
    }
    private void SetTargetGravityTxt(string vel)
    {
        targetVel.text = vel;
    }
    public void SetJumpForce(float value)
    {
        // _pLayerJump = FindObjectOfType<Jump>();
        _pLayerJump.SetJumpForce(value);
        SetJump(_pLayerJump.GetJumpForce().ToString());
    }
    public void SetGravity(float value)
    {
        // _pLayerJump = FindObjectOfType<Jump>();
        _pLayerJump.SetGravity(-value);
        SetTargetGravityTxt(_pLayerJump.GetGravity().ToString());
    }
}

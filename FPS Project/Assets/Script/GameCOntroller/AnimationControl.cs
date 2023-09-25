using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        SetTriggerAnim("Ready");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTriggerAnim(string name)
    {
        animator.SetTrigger(name);
    }
}

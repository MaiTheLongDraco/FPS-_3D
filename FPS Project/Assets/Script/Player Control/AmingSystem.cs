using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmingSystem : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject crossHair;

    private bool test;
    public void SetAim(bool set)
    {
        Debug.Log($"TEST: {test} --- SET: {set}");
        // if (test = set) return;
        test = set;
        animator.SetBool("isAming", test);
    }
    public void SetActiveCrossHair(bool set)
    {
        crossHair.SetActive(set);
    }
    public void SetActiveCrossHair()
    {
        crossHair.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmingSystem : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject crossHair;
    public void SetAim(bool set)
    {
        animator.SetBool("isAming", set);
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

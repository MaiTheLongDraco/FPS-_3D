using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GunSoundInfo gunSoundInfo;
    // Start is called before the first frame update
    void Start()
    {
        gunSoundInfo = GetComponent<GunSoundInfo>();
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        gunSoundInfo.PlayReady();
        SetTriggerAnim("Ready");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetTriggerAnim(string name)
    {
        // if (animator.runtimeAnimatorController != null)
        // {
        //     AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        //     foreach (var clip in clips)
        //     {
        //         if (clip.name == name)
        //         {
        //             animator.SetTrigger(name);
        //         }
        //         else break;
        //     }
        // }
        animator.SetTrigger(name);

    }
}

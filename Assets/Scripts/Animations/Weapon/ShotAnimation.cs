using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShotAnimation : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public CartridgeCaseExtraction extraction;
    public UnityEvent shooting;

    Animator animator;

    void Start()
    {
        muzzleFlash.Stop();
        animator = GetComponent<Animator>();
    }

    public void play()
    {
        animator.SetBool("Shot", true);
    }
    public void firingStart()
    {
        muzzleFlash.Play();
        //shooting?.Invoke();
    }
    public void firingEnd()
    {
        animator.SetBool("Shot", false);
        muzzleFlash.Stop();
        shooting?.Invoke();
    }
    public void extractionMoment() => extraction.cartridgeExtraction();

    //public void shotDone()
    //{
    //    animator.SetTrigger("Shot");
    //}
    //public void shotEnd()
    //{
    //   // shot.Invoke();
    //}
}

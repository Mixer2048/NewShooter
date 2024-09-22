using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAnimation : MonoBehaviour
{
    Animator animator;

    void Start() => animator = GetComponent<Animator>();

    public void shotDone()
    {
        animator.SetTrigger("Shot");
    }
}

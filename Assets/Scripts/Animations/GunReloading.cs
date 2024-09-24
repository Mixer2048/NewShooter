using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunReloading : MonoBehaviour
{
    Animator animator;
    public UnityEvent reloading;

    void Start() => animator = GetComponent<Animator>();

    public void reload()
    {
        animator.SetTrigger("Reload");
    }
    public void reloadingEnd()
    {
        //Debug.Log("ReloadingEnd");
        reloading?.Invoke();
    }
}

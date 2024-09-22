using UnityEngine;

public class SimpleTargetAnimation : MonoBehaviour
{
    private Animator _animator;

    public void GetOnPosition() => _animator.SetBool("Triggered", true);
    public void Defeated()
    {
        if (!_animator.GetBool("Triggered"))
            return;

        _animator.SetBool("Triggered", false);
        _animator.SetBool("Hitted", true);
    }

    private void Start() => _animator = GetComponent<Animator>();
}

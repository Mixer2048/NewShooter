using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    public void OpenDoor() => _animator.SetBool("Open", true);

    private void Start() => _animator = GetComponent<Animator>();
}

using UnityEngine;
using UnityEngine.Events;

public class SimpleTarget : MonoBehaviour
{
    public UnityEvent TargetHitted;
    public void OnHit() => TargetHitted?.Invoke();
}

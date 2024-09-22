using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetHit : MonoBehaviour
{
    public UnityEvent<eventParametrs> onTargetHit;

    public void targetHit(Vector3 playerPosition, Vector3 hitPoint, float impulse)
    {
        Debug.Log("invoke");
        onTargetHit?.Invoke(new eventParametrs(playerPosition, hitPoint, impulse));
    }
}

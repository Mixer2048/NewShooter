using UnityEngine;
using UnityEngine.Events;

public class TargetHit : MonoBehaviour
{
    public UnityEvent<eventParametrs> onTargetHit;

    public void targetHit(Vector3 playerPosition, Vector3 hitPoint, float impulse) => onTargetHit?.Invoke(new eventParametrs(playerPosition, hitPoint, impulse));
}

using UnityEngine;
using UnityEngine.Events;

public class TargetActivation : MonoBehaviour
{
    public UnityEvent PlayerOnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerOnPosition?.Invoke();
    }
}

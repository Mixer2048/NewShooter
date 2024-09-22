using UnityEngine;

public class PhysicalTarget : MonoBehaviour
{
    Rigidbody _rb;

    public void OnHit(eventParametrs param)
    {
        Vector3 dir = transform.position - param.playerPosition;
        dir.Normalize();

        _rb.AddForceAtPosition(dir * param.impulse, param.hitPoint, ForceMode.Impulse);
    }

    private void Start() => _rb = GetComponent<Rigidbody>();
}

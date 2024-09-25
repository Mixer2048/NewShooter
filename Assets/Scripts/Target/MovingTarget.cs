using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingTarget : MonoBehaviour
{
    [SerializeField] private Transform _destinationPoint;
    [SerializeField, Range(1f, 20f)] private float _speed = 2f;
    
    private Rigidbody _rb;
    private Vector3 _startPoint;
    private bool _returning = false;
    private bool _stopped = true;
    private float _ignoreTime = 0;

    public void Activate() => _stopped = false;

    public void OnTargetHit() => _stopped = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _startPoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (_stopped) return;

        Vector3 moveDirection = (_destinationPoint.position - _startPoint).normalized * _speed;

        if (_ignoreTime <= 0)
        {
            if (Vector3.Distance(_rb.transform.position, _destinationPoint.position) < 0.2f)
            {
                _returning = true;
            }

            if (Vector3.Distance(_rb.transform.position, _startPoint) < 0.2f)
            {
                _returning = false;
            }
        }
        else
            _ignoreTime--;

        if (!_returning)
            _rb.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime);
        else
            _rb.MovePosition(transform.position - moveDirection * Time.fixedDeltaTime);
    }
}

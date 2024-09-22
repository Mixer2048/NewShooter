using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public UnityEvent<int, int> OnAmmoAmountChanged;

    [SerializeField] private Camera _mainCamera;
    [SerializeField, Range(0.1f, 30f)] private float _impulse = 2.4f;
    [SerializeField, Range(0.1f, 30f)] private float _shootDelay = 5f;
    [SerializeField, Range(1, 100)] private int _maxAmmoAmount = 30;

    private int _currentAmmoAmount;
    private float _timeBetweenShoots = 0f;

    private void Start() => _currentAmmoAmount = _maxAmmoAmount;

    private void Update()
    {
        int previousAmmoAmount = _currentAmmoAmount;

        _timeBetweenShoots -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _timeBetweenShoots < 0 && _currentAmmoAmount > 0)
            Shot();

        if (Input.GetKeyDown(KeyCode.R) && _currentAmmoAmount < _maxAmmoAmount)
            Reload();

        if (previousAmmoAmount != _currentAmmoAmount)
            OnAmmoAmountChanged?.Invoke(_currentAmmoAmount, _maxAmmoAmount);
    }

    private void Shot()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Target"))
                hit.transform.GetComponent<TargetHit>().targetHit(transform.position, hit.point, _impulse);

            ImpactEffect impactEffect = hit.transform.GetComponent<ImpactEffect>();

            if (impactEffect != null)
                impactEffect.play(hit.point, hit.normal);
        }

        _currentAmmoAmount--;
        _timeBetweenShoots = _shootDelay;
    }

    private void Reload()
    {
        _currentAmmoAmount = _maxAmmoAmount;
    }
}

using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField, Range(0.1f, 30f)] private float _impulse = 2.4f;
    [SerializeField, Range(0.1f, 30f)] private float _shootDelay = 5f;
    [SerializeField, Range(1, 100)] private int _ammoAmount = 30;

    Animator _animator;


    private int _currentAmmoAmount;
    private float _timeBetweenShoots = 0f;

    private void Start()
    {
        _currentAmmoAmount = _ammoAmount;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _timeBetweenShoots -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _timeBetweenShoots < 0 && _currentAmmoAmount > 0)
        {
            Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Target"))
                    hit.transform.GetComponent<TargetHit>().targetHit(transform.position, hit.point, _impulse);
                Debug.Log(hit.transform);
                ImpactEffect impactEffect = hit.transform.GetComponent<ImpactEffect>();
                Debug.Log(impactEffect);
                if (impactEffect != null)
                    impactEffect.play(hit.point, hit.normal);
            }

            _currentAmmoAmount--;
            _timeBetweenShoots = _shootDelay;
        }

        if (Input.GetKeyDown(KeyCode.R) && _currentAmmoAmount < _ammoAmount)
        {
            _currentAmmoAmount = _ammoAmount;
        }
    }
}

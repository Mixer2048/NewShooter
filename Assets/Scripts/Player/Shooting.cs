using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public UnityEvent<int, int> OnAmmoAmountChanged;

    [SerializeField] private Camera _mainCamera;
    [SerializeField, Range(0.1f, 30f)] private float _impulse = 2.4f;
    //[SerializeField, Range(0.1f, 30f)] private float _shootDelay = 5f;
    [SerializeField, Range(1, 100)] private int _maxAmmoAmount = 30;

    [SerializeField] private AnimationClip ShootClip;
    private float ClipDuration;
    //float timeBetweenReloads;

    private int _currentAmmoAmount;
    private float _timeBetweenShoots = 0f;

    private bool reloading = false;

    public ShotAnimation shotAnimation;
    public GunReloading gunReloading;

    private void Start()
    {
        _currentAmmoAmount = _maxAmmoAmount;
        ClipDuration = ShootClip.length;
        _timeBetweenShoots = ClipDuration;
    }

    private void Update()
    {
        int previousAmmoAmount = _currentAmmoAmount;

        _timeBetweenShoots -= Time.deltaTime;

        if (_timeBetweenShoots < 0)
        {   
            if (Input.GetMouseButton(0) && _currentAmmoAmount > 0 && reloading == false)
                Shot();
        }

        if (Input.GetKeyDown(KeyCode.R) && _currentAmmoAmount < _maxAmmoAmount && reloading == false)
            reloadStart();

        //Debug.Log(previousAmmoAmount != _currentAmmoAmount);
        if (previousAmmoAmount != _currentAmmoAmount)
            OnAmmoAmountChanged?.Invoke(_currentAmmoAmount, _maxAmmoAmount);
    }

    private void Shot()
    {
        shotAnimation.play();
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
        _timeBetweenShoots = ClipDuration;
    }

    private void reloadStart()
    {
        reloading = true;
        gunReloading.reload();
    }
    public void reloadEnd()
    {
        _currentAmmoAmount = _maxAmmoAmount;
        //Debug.Log("reloadEND");
        //OnAmmoAmountChanged?.Invoke(_currentAmmoAmount, _maxAmmoAmount);
        //_animator.SetBool("PressReload", true);
        reloading = false;
        OnAmmoAmountChanged?.Invoke(_currentAmmoAmount, _maxAmmoAmount);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public UnityEvent<int, int> OnAmmoAmountChanged;

    [SerializeField] private Camera _mainCamera;
    [SerializeField, Range(0.1f, 30f)] private float _impulse = 2.4f;
    [SerializeField, Range(0.1f, 30f)] private float _shootDelay = 5f;
    [SerializeField, Range(1, 100)] private int _maxAmmoAmount = 30;

    //[SerializeField] private AnimationClip ReloadClip;
    //private float ClipDuration;
    //float timeBetweenReloads;

    Animator _animator;

    private int _currentAmmoAmount;
    private float _timeBetweenShoots = 0f;

    private bool reloading = false;
    private bool shooting = false;

    public ShotAnimation shotAnimation;
    public GunReloading gunReloading;

    private void Start()
    {
        _currentAmmoAmount = _maxAmmoAmount;
        _animator = GetComponent<Animator>();
        //ClipDuration = ReloadClip.length;
        //timeBetweenReloads = ClipDuration;
    }

    private void Update()
    {
        int previousAmmoAmount = _currentAmmoAmount;

        _timeBetweenShoots -= Time.deltaTime;
        //timeBetweenReloads -= Time.deltaTime;
        //if (timeBetweenReloads < 0)
        //{
           // _animator.SetBool("PressReload", false);
            //timeBetweenReloads = ClipDuration;
        //}

        if (_timeBetweenShoots < 0)
        {
            //_animator.SetBool("ShotCheck", false);
            if (Input.GetMouseButton(0) && _currentAmmoAmount > 0 && reloading == false && shooting == false)
                Shot();
        }

        if (Input.GetKeyDown(KeyCode.R) && _currentAmmoAmount < _maxAmmoAmount && reloading == false)
            reloadStart();

        //Debug.Log(previousAmmoAmount != _currentAmmoAmount);
        if (previousAmmoAmount != _currentAmmoAmount)
        {
            OnAmmoAmountChanged?.Invoke(_currentAmmoAmount, _maxAmmoAmount);
            //Debug.Log("AmmoChanged");
        }
        //Debug.Log(_currentAmmoAmount + " " + previousAmmoAmount);
    }

    private void Shot()
    {
        shooting = true;
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
        _timeBetweenShoots = _shootDelay;
        //_animator.SetBool("ShotCheck", true);
    }
    public void ShotStop()
    {
        shooting = false;
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

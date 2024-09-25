using UnityEngine;
using UnityEngine.Events;

public class GunLogic : MonoBehaviour
{
    //public UnityEvent<int, int, int> OnAmmoAmountChanged;

    [SerializeField] private Camera _mainCamera;
    [SerializeField, Range(0.1f, 30f)] private float _impulse = 2.4f;
    //[SerializeField, Range(0.1f, 30f)] private float _shootDelay = 5f;
    //[SerializeField, Range(1, 100)] private int _shooting.MaxAmmo = 5;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private AnimationClip ShootClip;
    private float ClipDuration;
    //float timeBetweenReloads;

    //private int _shooting.CurrentAmmo;
    private float _timeBetweenShoots = 0f;

    private bool reloading = false;

    public ShotAnimation shotAnimation;
    public GunReloading gunReloading;

    private void Start()
    {
        //_shooting.CurrentAmmo = _shooting.MaxAmmo;
        ClipDuration = ShootClip.length;
        _timeBetweenShoots = ClipDuration;
    }

    private void Update()
    {
        //int previousAmmoAmount = _shooting.CurrentAmmo;

        _timeBetweenShoots -= Time.deltaTime;

        /*if (_timeBetweenShoots < 0)
        {   
            if (Input.GetMouseButton(0) && _shooting.CurrentAmmo > 0 && reloading == false)
                Shot();
        }*/

        /*if (Input.GetKeyDown(KeyCode.R) && _shooting.CurrentAmmo < _shooting.MaxAmmo && reloading == false)
            reloadStart();*/

        //Debug.Log(previousAmmoAmount != _shooting.CurrentAmmo);
        //if (previousAmmoAmount != _shooting.CurrentAmmo)
        //    OnAmmoAmountChanged?.Invoke(_shooting.CurrentAmmo, _shooting.MaxAmmo, _shooting.StockAmmo);
    }

    public void Shot()
    {
        if (_timeBetweenShoots < 0 && reloading == false)
            shotAnimation.play();
        else
            return;

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

        _shooting.CurrentAmmo--;
        _timeBetweenShoots = ClipDuration;
        //OnAmmoAmountChanged?.Invoke(_shooting.CurrentAmmo, _shooting.MaxAmmo, _shooting.StockAmmo);
    }

    public void reloadStart()
    {
        if (reloading == true) return;

        reloading = true;
        gunReloading.reload();
    }
    public void reloadEnd()
    {
        //_shooting.StockAmmo += _shooting.CurrentAmmo - _shooting.MaxAmmo;
        //OnAmmoAmountChanged?.Invoke(_shooting.CurrentAmmo, _shooting.MaxAmmo);
        //_animator.SetBool("PressReload", true);
        reloading = false;
        //OnAmmoAmountChanged?.Invoke(_shooting.CurrentAmmo, _shooting.MaxAmmo, _shooting.StockAmmo);
    }
}

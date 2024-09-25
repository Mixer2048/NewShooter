using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    public UnityEvent<int, int, int> OnAmmoAmountChanged;

    [SerializeField] private GunLogic _leftGun;
    [SerializeField] private GunLogic _rightGun;
    [SerializeField] private AnimationClip ShootClip;

    public int StockAmmo = 20;
    public int CurrentAmmo = 10;
    public int MaxAmmo = 10;

    private float ClipDuration;
    private bool shootLeft = false;
    private float _timeBetweenShoots = 1f;

    private void Start()
    {
        ClipDuration = ShootClip.length - 0.2f;
        _timeBetweenShoots = ClipDuration;
    }

    private void Update()
    {
        _timeBetweenShoots -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _timeBetweenShoots < 0 && CurrentAmmo > 0)
        {
            Debug.Log(shootLeft);
            if (!shootLeft)
            {
                Debug.Log("right");
                _rightGun.Shot();
                shootLeft = true;
            }
            else
            {
                Debug.Log("left");
                _leftGun.Shot();
                shootLeft = false;
            }

            OnAmmoAmountChanged?.Invoke(CurrentAmmo, MaxAmmo, StockAmmo);

            _timeBetweenShoots = ClipDuration;
        }

        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo < MaxAmmo && StockAmmo > 0)
        {
            _leftGun.reloadStart();
            _rightGun.reloadStart();

        }
    }

    public void ReloadEnd()
    {
        int reloadAmmo = CurrentAmmo - MaxAmmo;
        StockAmmo += reloadAmmo;
        CurrentAmmo -= reloadAmmo;

        OnAmmoAmountChanged?.Invoke(CurrentAmmo, MaxAmmo, StockAmmo);

        _leftGun.reloadEnd();
        _rightGun.reloadEnd();
    }
}

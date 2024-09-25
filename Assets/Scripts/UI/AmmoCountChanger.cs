using TMPro;
using UnityEngine;

public class AmmoCountChanger : MonoBehaviour
{
    private TMP_Text _ammoCountText;
    //private TMP_Text magazineCount;
    public void ChangeAmmoAmount(int currentAmmoAmount, int maxAmmoCapacity, int stockAmmo) => _ammoCountText.text = $"{currentAmmoAmount}/{maxAmmoCapacity}  {stockAmmo}";
    private void Awake() => _ammoCountText = GetComponent<TMP_Text>();
}
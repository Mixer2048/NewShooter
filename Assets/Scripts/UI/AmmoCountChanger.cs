using TMPro;
using UnityEngine;

public class AmmoCountChanger : MonoBehaviour
{
    private TMP_Text _ammoCountText;
    public void ChangeAmmoAmount(int currentAmmoAmount, int maxAmmoAmount) => _ammoCountText.text = $"{currentAmmoAmount}/{maxAmmoAmount}";
    private void Awake() => _ammoCountText = GetComponent<TMP_Text>();
}
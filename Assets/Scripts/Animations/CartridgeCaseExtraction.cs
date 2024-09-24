using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartridgeCaseExtraction : MonoBehaviour
{
    public GameObject cartridgePrefab;

    public Transform extractionPoint;

    [Range(1, 100)]
    public float force = 5;

    public void cartridgeExtraction()
    {
        GameObject cartridge = Instantiate(cartridgePrefab, extractionPoint.position, Quaternion.identity);
        cartridge.GetComponent<Rigidbody>().AddForce(extractionPoint.right * force, ForceMode.Impulse);
        Destroy(cartridge, 10);
    }
}

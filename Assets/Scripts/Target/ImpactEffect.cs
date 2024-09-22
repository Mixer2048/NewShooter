using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    public GameObject impactEffect;

    public void play(Vector3 hitPoint, Vector3 normal)
    {
        Quaternion r = Quaternion.LookRotation(normal);
        GameObject effect = Instantiate(impactEffect, hitPoint, r);
        Destroy(effect, 0.5f);
    }
}

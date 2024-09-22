using UnityEngine;

public class ExplosionTarget : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;

    public void OnHit()
    {
        ParticleSystem ps = Instantiate(_explosion, transform.position, Quaternion.identity);
        ps.Play();
        Destroy(ps.gameObject, 1.2f);
        Destroy(gameObject);
    }
}

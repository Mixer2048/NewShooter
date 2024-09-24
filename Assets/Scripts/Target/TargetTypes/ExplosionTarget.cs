using UnityEngine;

public class ExplosionTarget : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField, Range(0.1f, 100f)] private float _explosionImpulse = 4f;
    [SerializeField, Range(0.1f, 100f)] private float _explosionRadius = 3f;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private bool _drawGizmo = false;

    public void OnHit()
    {
        ParticleSystem ps = Instantiate(_explosion, transform.position, Quaternion.identity);
        ps.Play();
        Explode();

        Destroy(ps.gameObject, 1.2f);
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _targetLayer);

        foreach (Collider collider in colliders)
        {
            Ray ray = new Ray(transform.position, collider.transform.position);
            RaycastHit hit;

            Physics.Raycast(ray, out hit);
            collider.GetComponent<TargetHit>().targetHit(transform.position, hit.point, _explosionImpulse);
        }
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmo)
            Gizmos.DrawSphere(transform.position, _explosionRadius);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class ChallengeCompete : MonoBehaviour
{
    public UnityEvent OnAllTargetsDefeated;
    [SerializeField] private Vector3 _challengeBorder;
    [SerializeField] private bool _drawGizmo = true;
    [SerializeField] private LayerMask _targetLayer;
    private int _defeatedTargets = 0;
    private int _targetsAmount;

    public void TargetDefeated()
    {
        _defeatedTargets++;

        Debug.Log(_defeatedTargets);

        if (_defeatedTargets == _targetsAmount)
            AllTargetsDefeated();
    }

    private void AllTargetsDefeated() => OnAllTargetsDefeated?.Invoke();

    private void Start()
    {
        Collider[] targets = Physics.OverlapBox(transform.position, _challengeBorder, Quaternion.identity, _targetLayer);
        _targetsAmount = targets.Length;
        Debug.Log(_targetsAmount);
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmo)
            Gizmos.DrawCube(transform.position, _challengeBorder);
    }
}

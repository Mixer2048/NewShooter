using UnityEngine;

public class eventParametrs
{
    public Vector3 playerPosition;
    public Vector3 hitPoint;
    public float impulse;

    public eventParametrs(Vector3 playerPosition, Vector3 hitPoint, float impulse)
    {
        this.playerPosition = playerPosition;
        this.hitPoint = hitPoint;
        this.impulse = impulse;
    }
}

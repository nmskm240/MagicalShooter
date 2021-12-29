using UnityEngine;

class Straight : IMotion
{
    public Vector2 Play(Vector3 up, float speed)
    {
        return up * speed;
    }
}
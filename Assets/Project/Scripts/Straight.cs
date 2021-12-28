using UnityEngine;

class Straight : IMotion
{
    public Vector2 Play(float speed)
    {
        return Vector2.up * speed;
    }
}
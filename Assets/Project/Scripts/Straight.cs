using UnityEngine;

class Straight : IMotion
{
    public Vector3 Play(float speed)
    {
        return Vector3.up * Time.deltaTime * speed;
    }
}
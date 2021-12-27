using UnityEngine;

class Straight : IMotion
{
    public void Move(Transform transform, float speed)
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
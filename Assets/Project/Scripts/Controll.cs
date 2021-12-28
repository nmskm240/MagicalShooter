using UnityEngine;

class Controll : IMotion
{
    public Vector3 Play(float speed)
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var dir = new Vector3(x, y, 0).normalized;
        return dir * speed;
    }
}
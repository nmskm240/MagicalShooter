using UnityEngine;

class Controll : IMotion
{
    public Vector2 Play(float speed)
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var dir = new Vector2(x, y).normalized;
        return dir * speed;
    }
}
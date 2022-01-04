using UnityEngine;

namespace Shooting.Motions
{
    public interface IMotion
    {
        Vector2 Play(Vector3 up, float speed);
    }
}
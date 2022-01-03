using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(IMotion motion, float speed)
    {
        _rigidbody.velocity = motion.Play(Vector2.down, speed);
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
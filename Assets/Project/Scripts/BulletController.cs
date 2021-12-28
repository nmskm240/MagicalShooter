using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [SerializeField]
    private BulletData _data;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        foreach (var motion in _data.Motions)
        {
            _rigidbody.velocity = motion.Play(_data.Speed);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
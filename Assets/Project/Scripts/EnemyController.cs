using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeReference, SubclassSelector]
    private List<IMotion> _motions;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        foreach (var motion in _motions)
        {
            _rigidbody.velocity = motion.Play(Vector2.down, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }    
    }
}
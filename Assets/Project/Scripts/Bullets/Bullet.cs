using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Shooting.Characters;

namespace Shooting.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletData _model;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            this.OnTriggerEnter2DAsObservable()
                .Select(collider => collider.gameObject.GetComponent<IDamageable>())
                .Where(damageable => damageable != null && damageable.CanHit)
                .Subscribe(damageable =>
                {
                    damageable.TakeDamage(_model.Power);
                    Destroy(gameObject);
                });
            _model.OnMotionChanged
                .Subscribe(motion =>
                {
                    _rigidbody.velocity = motion.Play(transform.up, _model.Speed);
                });
        }
    }
}
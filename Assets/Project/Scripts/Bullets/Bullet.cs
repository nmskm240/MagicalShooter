using UnityEngine;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using Shooting.Characters;
using Shooting.Motions;

namespace Shooting.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private BulletData _model;

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
            _model.DoMove(transform);
        }
    }
}
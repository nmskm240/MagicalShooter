using System.Collections.Generic;
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
        private BulletData _model;

        private void Start()
        {
            var value = gameObject.layer == LayerMask.NameToLayer("PlayersBullet") ? 0 : 180;
            transform.rotation = Quaternion.AngleAxis(value, Vector3.up);
            this.OnTriggerEnter2DAsObservable()
                .Select(collider => collider.gameObject.GetComponent<IDamageable>())
                .Where(damageable => damageable != null && damageable.CanHit)
                .Subscribe(damageable =>
                {
                    damageable.TakeDamage(_model.Power);
                    Destroy(gameObject);
                });
            _model.DoMove(transform, transform.right);
        }

        public void Init(BulletData model)
        {
            _model = model;
        }
    }
}
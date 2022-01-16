using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using Shooting.Characters;
using Shooting.Motions;

namespace Shooting.Bullets
{
    [RequireComponent(typeof(BulletView), typeof(Rigidbody2D))]
    public class Bullet : Presenter<BulletData, BulletView>
    {
        private void Start()
        {
            _view.ChangeBaseAngle();
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
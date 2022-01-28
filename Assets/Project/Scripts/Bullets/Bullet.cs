using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using MagicalShooter.Characters;
using MagicalShooter.Motions;

namespace MagicalShooter.Bullets
{
    [RequireComponent(typeof(BulletView), typeof(Rigidbody2D))]
    public class Bullet : Presenter<BulletData, BulletView>
    {
        private readonly Subject<Unit> _returnPool = new Subject<Unit>();

        public IObservable<Unit> OnReturnPool { get { return _returnPool.Take(1); } }

        private void OnEnable()
        {
            this.OnTriggerEnter2DAsObservable()
                .TakeUntilDisable(this)
                .Select(collider => collider.gameObject.GetComponent<IDamageable>())
                .Where(damageable => damageable != null && damageable.CanHit)
                .Subscribe(damageable =>
                {
                    damageable.TakeDamage(_model.Power);
                    _returnPool.OnNext(Unit.Default);
                });
            this.OnBecameInvisibleAsObservable()
                .TakeUntilDisable(this)
                .Subscribe(_ => _returnPool.OnNext(Unit.Default));
        }

        private void OnDisable() 
        {
            _model.NowMotion.Kill();
        }

        public void Init(BulletData model)
        {
            _model = model;
            _view.ChangeBaseAngle();
            _model.DoMove(transform, transform.right);
        }
    }
}
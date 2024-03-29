using System;
using UnityEngine;
using DG.Tweening;
using UniRx;
using UniRx.Triggers;
using Shooting.Motions;

namespace Shooting.Characters.Enemies
{
    [RequireComponent(typeof(EnemyView))]
    public class Enemy : Character<EnemyData, EnemyView>
    {
        protected override void Start()
        {
            base.Start();
            this.OnTriggerEnter2DAsObservable()
                .Where(collider => collider.gameObject.CompareTag("Player"))
                .Select(collider => collider.gameObject.GetComponent<IDamageable>())
                .Where(damageable => damageable != null && damageable.CanHit)
                .Subscribe(damageable =>
                {
                    damageable.TakeDamage(1);
                });
            _model.DoMove(transform, -transform.right);
            _model.OnDead
                .Subscribe(_ => _model.NowMotion.Kill());
            this.UpdateAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(_model.Spell.CastingTime))
                .Subscribe(_ => _model.Spell.Active(gameObject));
        }
    }
}
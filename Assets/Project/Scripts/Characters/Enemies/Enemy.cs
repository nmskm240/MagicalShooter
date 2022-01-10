using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Shooting.Motions;
using Shooting.Utils;

namespace Shooting.Characters.Enemies
{
    [RequireComponent(typeof(EnemyView))]
    public class Enemy : Character<EnemyData, EnemyView>
    {
        protected override void Start()
        {
            base.Start();
            _model.DoMove(transform);
            this.OnTriggerEnter2DAsObservable()
                .Where(collider => collider.gameObject.CompareTag("Player"))
                .Select(collider => collider.gameObject.GetComponent<IDamageable>())
                .Where(damageable => damageable != null && damageable.CanHit)
                .Subscribe(damageable =>
                {
                    damageable.TakeDamage(1);
                });
            _model.DoMove(transform);
        }
    }
}
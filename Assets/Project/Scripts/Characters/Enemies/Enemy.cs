using UnityEngine;
using UniRx;
using Shooting.Utils;

namespace Shooting.Characters.Enemies
{
    [RequireComponent(typeof(Rigidbody2D), typeof(EnemyView))]
    public class Enemy : Character<EnemyData, EnemyView>
    {
        private void Start()
        {
            _model.DoMove(transform);
            _model.OnDead.Subscribe(_ =>
            {
                _view.Explosion();
            });
        }
    }
}
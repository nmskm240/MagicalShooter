using UnityEngine;
using UniRx;
using Shooting.Motions;
using Shooting.Utils;

namespace Shooting.Characters.Enemies
{
    [RequireComponent(typeof(EnemyView))]
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
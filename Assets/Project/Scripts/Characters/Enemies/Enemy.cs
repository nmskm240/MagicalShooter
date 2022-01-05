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
            var move = _model.OnMotionChanged
                .Subscribe(motion =>
                {
                    _rigidbody.velocity = motion.Play(-transform.up, _model.Speed);
                });
            _model.OnDead.Subscribe(_ =>
            {
                move.Dispose();
                _view.Explosion();
            });
        }
    }
}
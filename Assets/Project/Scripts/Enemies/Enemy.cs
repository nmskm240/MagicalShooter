using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Shooting.Utils;

namespace Shooting.Enemies
{
    [RequireComponent(typeof(EnemyView), typeof(Rigidbody2D))]
    public class Enemy : ScriptableObjectInstancePresenter<EnemyData>, IDamageable
    {
        private EnemyView _view;
        private Rigidbody2D _rigidbody;

        public bool CanHit { get { return _model.CanHit; } }

        protected override void Awake()
        {
            base.Awake();
            _view = GetComponent<EnemyView>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

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

        public void TakeDamage(int power)
        {
            _model.Damage(power);
        }
    }
}
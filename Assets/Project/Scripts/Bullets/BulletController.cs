using UnityEngine;
using Shooting;
using Shooting.Utils;

namespace Shooting.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletController : ScriptableObjectInstancePresenter<BulletData>, IAttacker
    {
        private Rigidbody2D _rigidbody;

        public int Power { get { return _model.Power; } }

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            foreach (var motion in _model.Motions)
            {
                _rigidbody.velocity = motion.Play(transform.up, _model.Speed);
            }
        }

        public void OnAttacked()
        {
            Destroy(gameObject);
        }
    }
}
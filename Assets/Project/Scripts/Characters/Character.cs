using UnityEngine;
using Shooting.Utils;

namespace Shooting.Characters
{
    public abstract class Character<TModel, TView> : ScriptableObjectInstancePresenter<TModel, TView>, IDamageable
        where TModel : CharacterData
        where TView : CharacterView
    {
        protected Rigidbody2D _rigidbody;

        public bool CanHit { get { return _model.CanHit; } }

        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void TakeDamage(int power)
        {
            _model.Damage(power);
        }
    }
}
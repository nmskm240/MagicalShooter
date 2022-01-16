using UnityEngine;
using UniRx;

namespace Shooting.Characters
{
    public abstract class Character<TModel, TView> : Presenter<TModel, TView>, IDamageable
        where TModel : CharacterData
        where TView : CharacterView
    {
        public bool CanHit { get { return _model.CanHit; } }

        protected virtual void Start()
        {
            _model.OnDead.Subscribe(_ =>
            {
                _view.Explosion();
            });
        }

        public void TakeDamage(int power)
        {
            _model.Damage(power);
        }
    }
}
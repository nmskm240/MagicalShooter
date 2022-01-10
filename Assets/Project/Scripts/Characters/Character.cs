using UnityEngine;
using UniRx;
using Shooting.Utils;

namespace Shooting.Characters
{
    public abstract class Character<TModel, TView> : ScriptableObjectInstancePresenter<TModel, TView>, IDamageable
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
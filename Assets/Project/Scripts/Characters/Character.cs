using UnityEngine;
using Shooting.Utils;

namespace Shooting.Characters
{
    public abstract class Character<TModel, TView> : ScriptableObjectInstancePresenter<TModel, TView>, IDamageable
        where TModel : CharacterData
        where TView : CharacterView
    {
        public bool CanHit { get { return _model.CanHit; } }

        public void TakeDamage(int power)
        {
            _model.Damage(power);
        }
    }
}
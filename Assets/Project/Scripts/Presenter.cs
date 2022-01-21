using UnityEngine;

namespace MagicalShooter
{
    public abstract class Presenter<TModel, TView> : MonoBehaviour
        where TView : Component
    {
        protected TModel _model { get; set; }
        protected TView _view { get; set; }

        protected virtual void Awake()
        {
            _view = GetComponent<TView>();
        }
    }
}
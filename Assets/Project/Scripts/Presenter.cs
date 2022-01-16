using UnityEngine;

namespace Shooting
{
    public abstract class Presenter<TModel, TView> : MonoBehaviour
        where TView : MonoBehaviour
    {
        protected TModel _model { get; set; }
        protected TView _view { get; set; }

        protected virtual void Awake()
        {
            _view = GetComponent<TView>();
        }
    }
}
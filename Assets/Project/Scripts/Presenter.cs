using UnityEngine;

namespace Shooting
{
    public abstract class Presenter<TModel, TView> : MonoBehaviour
        where TModel : ScriptableObject
        where TView : MonoBehaviour
    {
        [SerializeField]
        private TModel _original;
        protected TModel _model { get; set; }
        protected TView _view { get; set; }

        protected virtual void Awake()
        {
            _model = Instantiate<TModel>(_original);
            _view = GetComponent<TView>();
        }
    }
}
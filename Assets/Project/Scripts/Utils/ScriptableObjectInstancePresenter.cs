using UnityEngine;

namespace Shooting.Utils
{
    public abstract class ScriptableObjectInstancePresenter<TModel, TView> : Presenter<TModel, TView>
        where TModel : ScriptableObject
        where TView : MonoBehaviour
    {
        [SerializeField]
        private TModel _original;

        protected override void Awake()
        {
            base.Awake();
            _model = ScriptableObject.Instantiate<TModel>(_original);
        }
    }
}
using UnityEngine;

namespace MagicalShooter
{
    public abstract class ScriptableObjectPresenter<TModel, TView> : Presenter<TModel, TView>
        where TModel : ScriptableObject
        where TView : MonoBehaviour
    {
        [SerializeField]
        private TModel _original;

        protected override void Awake()
        {
            base.Awake();
            _model = Instantiate<TModel>(_original);
        }
    }
}
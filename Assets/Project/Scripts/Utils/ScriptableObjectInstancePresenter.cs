using UnityEngine;

namespace Shooting.Utils
{
    public abstract class ScriptableObjectInstancePresenter<T> : MonoBehaviour where T : ScriptableObject
    {
        [SerializeField]
        private T _original;
        protected T _model { get; private set; }

        protected virtual void Awake()
        {
            _model = ScriptableObject.Instantiate<T>(_original);
        }
    }
}
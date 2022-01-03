using UnityEngine;

public abstract class ScriptableObjectInstancePresenter<T> : MonoBehaviour where T : ScriptableObject
{

    public T _model;
    protected T model { get; set; }

    protected virtual void Awake()
    {
        model = ScriptableObject.Instantiate<T>(_model);
    }
}
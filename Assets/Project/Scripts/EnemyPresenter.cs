using UnityEngine;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(EnemyView), typeof(EnemyController))]
public class EnemyPresenter : ScriptableObjectInstancePresenter<EnemyData>
{
    private EnemyView _view;
    private EnemyController _controller;

    protected override void Awake()
    {
        base.Awake();
        _view = GetComponent<EnemyView>();
        _controller = GetComponent<EnemyController>();
    }

    private void Start()
    {
        var move = this.FixedUpdateAsObservable()
            .Subscribe(_ =>
            {
                foreach(var motion in _model.Motions)
                {
                    _controller.Move(motion, _model.Speed);
                }
            });
        var hit = this.OnTriggerEnter2DAsObservable()
            .Select(collider => collider.gameObject.CompareTag("PlayersBullet"))
            .Subscribe(_ =>
            {
                _model.Damage(1);
            });
        _model.OnDead.Subscribe(_ =>
        {
            move.Dispose();
            hit.Dispose();
            _controller.Stop();
            _view.Explosion();
        });
    }
}
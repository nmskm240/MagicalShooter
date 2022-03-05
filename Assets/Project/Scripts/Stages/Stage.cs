using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UniRx;

namespace MagicalShooter.Stages
{
    public class Stage : ScriptableObjectPresenter<StageData, StageView>
    {
        private void Start()
        {
            _view.OnEnemiesSpawnFinished
                .Subscribe(_ =>
                {
                    StartCoroutine(_model.WaitUntilEnemiesInvisibly());
                });
            _model.OnStageCleared
                .Subscribe(_ =>
                {
                    Debug.Log("o");
                });
            _view.SetBackgjroundTimelineAsset(_model.Background);
            _view.SetSpawnTableTimelineAsset(_model.SpawnTable);
            _view.Play();
        }
    }
}
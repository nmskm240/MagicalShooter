using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UniRx;

namespace MagicalShooter.Stages
{
    public class StageView : MonoBehaviour
    {
        [SerializeField]
        private PlayableDirector _backgroundPlayableDirector;
        [SerializeField]
        private PlayableDirector _spawnTablePlayableDirector;
        private Subject<Unit> _onEnemiesSpawnFinished = new Subject<Unit>();

        public IObservable<Unit> OnEnemiesSpawnFinished { get { return _onEnemiesSpawnFinished; } }

        private void OnEnable()
        {
            _spawnTablePlayableDirector.stopped += OnPlayableDirectorStopped;
        }

        private void OnDisable()
        {
            _spawnTablePlayableDirector.stopped -= OnPlayableDirectorStopped;
        }

        private void OnPlayableDirectorStopped(PlayableDirector director)
        {
            if (director.playableAsset.duration <= director.duration)
            {
                _onEnemiesSpawnFinished.OnNext(Unit.Default);
            }
        }

        public void SetBackgjroundTimelineAsset(TimelineAsset timelineAsset)
        {
            _backgroundPlayableDirector.playableAsset = timelineAsset;
        }

        public void SetSpawnTableTimelineAsset(TimelineAsset timelineAsset)
        {
            _spawnTablePlayableDirector.playableAsset = timelineAsset;
        }

        public void Play()
        {
            _backgroundPlayableDirector.Play();
            _spawnTablePlayableDirector.Play();
        }
    }
}
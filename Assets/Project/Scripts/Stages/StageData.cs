using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UniRx;
using UniRx.Triggers;

namespace MagicalShooter.Stages
{
    [CreateAssetMenu(fileName = "StageData", menuName = "MagicalShooter/StageData", order = 0)]
    public class StageData : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private TimelineAsset _background;
        [SerializeField]
        private TimelineAsset _spawnTable;
        private Subject<Unit> _onStageCleared = new Subject<Unit>();

        public string Name { get { return _name; } }
        public TimelineAsset Background { get { return _background; } }
        public TimelineAsset SpawnTable { get { return _spawnTable; } }
        public IObservable<Unit> OnStageCleared { get { return _onStageCleared; } }

        public IEnumerator WaitUntilEnemiesInvisibly()
        {
            yield return new WaitUntil(() =>
                GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
            _onStageCleared.OnNext(Unit.Default);
        }
    }
}
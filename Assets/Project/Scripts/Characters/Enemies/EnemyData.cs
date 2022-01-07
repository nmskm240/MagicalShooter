using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Motion = Shooting.Motions.Motion;

namespace Shooting.Characters.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Shooting/EnemyData", order = 0)]
    public class EnemyData : CharacterData
    {
        [SerializeField]
        private List<Motion> _motions;
        [NonSerialized]
        private ReactiveProperty<Motion> _currentMotion = new ReactiveProperty<Motion>();

        public IEnumerable<Motion> Motions { get { return _motions; } }
        public IObservable<Motion> OnMotionChanged { get { return _currentMotion; } }

        protected override void OnEnable()
        {
            base.OnEnable();
            _currentMotion.Value = _motions.First();
        }

        public void DoMove(Transform transform)
        {
            var sequence = DOTween.Sequence();
            foreach (var motion in _motions)
            {
                sequence.Append(motion.ToSequence(transform, _speed));
            }
            sequence
                .Play()
                .OnComplete(() => DoMove(transform));
        }
    }
}
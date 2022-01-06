using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Motion = Shooting.Motions.Motion;

namespace Shooting.Bullets
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Shooting/BulletData", order = 0)]
    public class BulletData : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField]
        private int _power;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private List<Motion> _motions;
        [NonSerialized]
        private ReactiveProperty<Motion> _currentMotion = new ReactiveProperty<Motion>();

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int Power { get { return _power; } }
        public float Speed { get { return _speed; } }
        public IEnumerable<Motion> Motions { get { return _motions; } }
        public IObservable<Motion> OnMotionChanged { get { return _currentMotion; } }

        private void OnEnable()
        {
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
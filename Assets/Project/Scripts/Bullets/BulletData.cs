using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Shooting.Motions;

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
        [SerializeReference, SubclassSelector]
        private List<IMotion> _motions;
        [NonSerialized]
        private ReactiveProperty<IMotion> _currentMotion = new ReactiveProperty<IMotion>();

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int Power { get { return _power; } }
        public float Speed { get { return _speed; } }
        public IEnumerable<IMotion> Motions { get { return _motions; } }
        public IObservable<IMotion> OnMotionChanged { get { return _currentMotion; } }

        private void OnEnable()
        {
            _currentMotion.Value = _motions.First();
        }
    }
}
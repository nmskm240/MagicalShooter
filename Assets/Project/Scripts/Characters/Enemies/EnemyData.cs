using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Shooting.Motions;

namespace Shooting.Characters.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Shooting/EnemyData", order = 0)]
    public class EnemyData : CharacterData
    {
        [SerializeReference, SubclassSelector]
        private List<IMotion> _motions;
        [NonSerialized]
        private ReactiveProperty<IMotion> _currentMotion = new ReactiveProperty<IMotion>();

        public IEnumerable<IMotion> Motions { get { return _motions; } }
        public IObservable<IMotion> OnMotionChanged { get { return _currentMotion; } }

        protected override void OnEnable()
        {
            base.OnEnable();
            _currentMotion.Value = _motions.First();
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Shooting.Motions;

namespace Shooting.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Shooting/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private float _speed;
        [SerializeReference, SubclassSelector]
        private List<IMotion> _motions;
        [NonSerialized]
        private int _beforeHP;
        [NonSerialized]
        private ReactiveProperty<int> _currentHP = new ReactiveProperty<int>();
        [NonSerialized]
        private ReactiveProperty<IMotion> _currentMotion = new ReactiveProperty<IMotion>();
        private Subject<int> _onDamaged = new Subject<int>();
        private Subject<Unit> _onDead = new Subject<Unit>();

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int MaxHP { get { return _maxHP; } }
        public int CurrentHP { get { return _currentHP.Value; } }
        public float Speed { get { return _speed; } }
        public IEnumerable<IMotion> Motions { get { return _motions; } }
        public IObservable<IMotion> OnMotionChanged { get { return _currentMotion; } }
        public IObservable<int> OnChangedHP { get { return _currentHP; } }
        public IObservable<int> OnDamaged { get { return _onDamaged; } }
        public IObservable<Unit> OnDead { get { return _onDead; } }
        public bool CanHit { get { return 0 < CurrentHP; } }

        protected virtual void OnEnable()
        {
            _currentHP.Value = _maxHP;
            _beforeHP = CurrentHP;
            _currentMotion.Value = _motions.First();
            OnChangedHP
                .Select(hp => Math.Abs(hp - _beforeHP))
                .Where(damage => 0 < damage)
                .Subscribe(damage => _onDamaged.OnNext(damage));
            OnDamaged
                .Where(_ => CurrentHP <= 0)
                .Subscribe(_ => _onDead.OnNext(Unit.Default));
        }

        public virtual void Damage(int power)
        {
            _currentHP.Value -= power;
        }
    }
}
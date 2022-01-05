using System;
using UnityEngine;
using UniRx;

namespace Shooting.Characters
{
    public abstract class CharacterData : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField]
        private int _maxHP;
        [SerializeField]
        private float _speed;
        [NonSerialized]
        private int _beforeHP;
        [NonSerialized]
        private ReactiveProperty<int> _currentHP = new ReactiveProperty<int>();
        [NonSerialized]
        private Subject<int> _onDamaged = new Subject<int>();
        [NonSerialized]
        private Subject<Unit> _onDead = new Subject<Unit>();

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int MaxHP { get { return _maxHP; } }
        public int CurrentHP { get { return _currentHP.Value; } }
        public float Speed { get { return _speed; } }
        public IObservable<int> OnChangedHP { get { return _currentHP; } }
        public IObservable<int> OnDamaged { get { return _onDamaged; } }
        public IObservable<Unit> OnDead { get { return _onDead; } }
        public bool CanHit { get { return 0 < CurrentHP; } }

        protected virtual void OnEnable()
        {
            _currentHP.Value = _maxHP;
            _beforeHP = CurrentHP;
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
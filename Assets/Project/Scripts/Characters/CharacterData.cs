using System;
using UnityEngine;
using UniRx;
using MagicalShooter.Spells;

namespace MagicalShooter.Characters
{
    public abstract class CharacterData : ScriptableObject
    {
        [SerializeField]
        protected string _name;
        [SerializeField, Multiline]
        protected string _detail;
        [SerializeField]
        protected int _maxHP;
        [SerializeField]
        protected float _speed;
        [SerializeField]
        protected Spell _spell;
        [NonSerialized]
        protected int _beforeHP;
        [NonSerialized]
        protected ReactiveProperty<int> _currentHP = new ReactiveProperty<int>();
        [NonSerialized]
        protected Subject<int> _onDamaged = new Subject<int>();
        [NonSerialized]
        protected Subject<Unit> _onDead = new Subject<Unit>();

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int MaxHP { get { return _maxHP; } }
        public int CurrentHP { get { return _currentHP.Value; } }
        public float Speed { get { return _speed; } }
        public Spell Spell { get { return _spell; } }
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
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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
    private int _currentHP;
    private Subject<Unit> _onDead = new Subject<Unit>();

    public string Name { get { return _name; } }
    public string Detail { get { return _detail; } }
    public int MaxHP { get { return _maxHP; } }
    public int CurrentHP { get { return _currentHP; } }
    public float Speed { get { return _speed; } }
    public IEnumerable<IMotion> Motions { get { return _motions; } }
    public IObservable<Unit> OnDead { get { return _onDead; } }

    protected virtual void OnEnable()
    {
        _currentHP = _maxHP;
    }

    public virtual void Damage(int power)
    {
        _currentHP -= power;
        if(_currentHP <= 0)
        {
            _currentHP = 0;
            _onDead.OnNext(Unit.Default);
        }
    }
}
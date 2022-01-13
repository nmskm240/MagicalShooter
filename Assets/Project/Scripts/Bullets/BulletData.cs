using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Shooting.Motions;

namespace Shooting.Bullets
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "Shooting/BulletData", order = 0)]
    public class BulletData : ScriptableObject, IAutoMotion
    {
        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField]
        private int _power;
        [SerializeField]
        private float _speed;
        private List<MotionData> _motions;

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int Power { get { return _power; } }
        public float Speed { get { return _speed; } }
        public IEnumerable<MotionData> Motions
        {
            get { return _motions; }
            set 
            {
                _motions.Clear();
                _motions.AddRange(value);
            }
        }
        public Sequence NowMotion { get; set; }

        private void OnEnable()
        {
            _motions = new List<MotionData>();
        }
    }
}
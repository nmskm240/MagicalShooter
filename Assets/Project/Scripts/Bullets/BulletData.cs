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
        private int _power;
        private float _speed;
        private List<MotionData> _motions = new List<MotionData>();

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int Power
        {
            get { return _power; }
            set { _power = value; }
        }
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
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
    }
}
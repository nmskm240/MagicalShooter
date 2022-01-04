using System.Collections.Generic;
using UnityEngine;
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
        private float _power;
        [SerializeField]
        private float _stamina;
        [SerializeField]
        private float _speed;
        [SerializeReference, SubclassSelector]
        private List<IMotion> _motions;

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public float Power { get { return _power; } }
        public float Stamina { get { return _stamina; } }
        public float Speed { get { return _speed; } }
        public IEnumerable<IMotion> Motions { get { return _motions; } }
    }
}
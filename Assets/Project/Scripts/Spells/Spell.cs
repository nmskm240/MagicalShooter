using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Shooting.Bullets;
using Shooting.Motions;

namespace Shooting.Spells
{
    public abstract class Spell : ScriptableObject
    {
        [System.Serializable]
        private class SpellBulletInfo
        {
            [SerializeField]
            private BulletDataSet _dataSet;
            [SerializeField, Range(0, 100)]
            private float _speed;
            [SerializeField, Range(0, 100)]
            private int _power;
            [SerializeField]
            private List<MotionData> _motions;

            public BulletDataSet DataSet { get { return _dataSet; } }
            public float Speed { get { return _speed; } }
            public int Power { get { return _power; } }
            public IEnumerable<MotionData> Motions { get { return _motions; } }
        }

        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField, Range(0f, float.PositiveInfinity)]
        private float _castingTime;
        [SerializeField]
        private List<SpellBulletInfo> _bulletInfos;
        private int _layer;

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public float CastingTime { get { return _castingTime; } }
        public int BulletCount { get { return _bulletInfos.Count(); } }

        protected abstract void OnActived(GameObject activator);

        protected GameObject CreateBulletAt(int index)
        {
            var clamped = Mathf.Clamp(index, 0, BulletCount - 1);
            var element = _bulletInfos.ElementAt(clamped);
            var dataSet = Instantiate(element.DataSet);
            var info = _bulletInfos.ElementAt(clamped);
            dataSet.Model.Motions = info.Motions;
            dataSet.Model.Power = info.Power;
            dataSet.Model.Speed = info.Speed;
            dataSet.Prefab.layer = _layer;
            return Instantiate(dataSet.Prefab);
        }

        public void Active(GameObject activator)
        {
            _layer = LayerMask.NameToLayer(activator.tag + "sBullet");
            OnActived(activator);
        }
    }
}
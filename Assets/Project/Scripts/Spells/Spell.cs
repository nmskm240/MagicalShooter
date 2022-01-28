using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using MagicalShooter.Bullets;
using MagicalShooter.Motions;

namespace MagicalShooter.Spells
{
    public abstract class Spell : ScriptableObject
    {
        [System.Serializable]
        private class SpellBulletInfo
        {
            [SerializeField]
            private BulletData _data;
            [SerializeField, Range(0, 100)]
            private float _speed;
            [SerializeField, Range(0, 100)]
            private int _power;
            [SerializeField]
            private List<MotionData> _motions;

            public BulletData Data { get { return _data; } }
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
            var obj = GameObject.FindWithTag("ObjectPoolProvider");
            var provider = obj.GetComponent<BulletObjectPoolProvider>();
            var clamped = Mathf.Clamp(index, 0, BulletCount - 1);
            var info = _bulletInfos.ElementAt(clamped);
            var bullet = provider.ObjectPool.Rent();
            var model = Instantiate(info.Data);
            model.Motions = info.Motions;
            model.Power = info.Power;
            model.Speed = info.Speed;
            bullet.gameObject.layer = _layer;
            bullet.Init(model);
            bullet.OnReturnPool
                .Subscribe(_ => provider.ObjectPool.Return(bullet));
            return bullet.gameObject;
        }

        public void Active(GameObject activator)
        {
            _layer = LayerMask.NameToLayer(activator.tag + "sBullet");
            OnActived(activator);
        }
    }
}
using UnityEngine;
using UniRx.Toolkit;

namespace MagicalShooter.Bullets
{
    public class BulletObjectPool : ObjectPool<Bullet>
    {
        private readonly Bullet _original;
        private readonly Transform _root;

        public BulletObjectPool(Bullet original)
        {
            _original = original;
            _root = new GameObject().transform;
            _root.name = "Bullets";
            _root.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        protected override Bullet CreateInstance()
        {
            var bullet = GameObject.Instantiate(_original, _root);
            return bullet;
        }
    }
}
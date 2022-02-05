using UnityEngine;

namespace MagicalShooter.Bullets
{
    public class BulletObjectPoolProvider : ObjectPoolProvider<Bullet>
    {
        [SerializeField]
        private Bullet _prefab;

        protected override void CreateObjectPool()
        {
            ObjectPool = new BulletObjectPool(_prefab);
        }
    }
}
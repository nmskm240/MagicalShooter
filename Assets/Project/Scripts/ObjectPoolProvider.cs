using UnityEngine;
using UniRx;
using UniRx.Toolkit;

namespace MagicalShooter
{
    public abstract class ObjectPoolProvider<TPoolComponent> : MonoBehaviour
        where TPoolComponent : Component, IPoolObject
    {
        public ObjectPool<TPoolComponent> ObjectPool { get; protected set; }

        private void Awake()
        {
            CreateObjectPool();
            // ObjectPool.PreloadAsync(20, 20).Subscribe();
        }

        private void OnDestroy()
        {
            ObjectPool.Dispose();
        }

        protected abstract void CreateObjectPool();
    }
}
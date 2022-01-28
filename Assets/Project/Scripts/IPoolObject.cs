using System;
using UniRx;

namespace MagicalShooter
{
    public interface IPoolObject
    {
        public IObservable<Unit> OnReturnPool { get; }
    }
}
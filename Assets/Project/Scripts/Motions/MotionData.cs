using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Shooting.Motions
{
    public abstract class MotionData : ScriptableObject
    {
        [SerializeField]
        protected float _speed;
        [SerializeField]
        protected Ease _ease = Ease.Linear;

        protected float ToSpeed(float speed)
        {
            return _speed / speed;
        }

        public abstract Sequence ToSequence(Transform transform, float speed);
    }
}
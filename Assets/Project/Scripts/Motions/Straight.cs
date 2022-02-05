using UnityEngine;
using DG.Tweening;

namespace MagicalShooter.Motions
{
    [CreateAssetMenu(fileName = "Straight", menuName = "MagicalShooter/Motions/Straight", order = 0)]
    public class Straight : MotionData
    {
        public override Sequence ToSequence(Transform transform, Vector2 forward, float speed)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(forward, ToSpeed(speed))
                        .SetEase(_ease)
                        .SetRelative(true));
            return sequence;
        }
    }
}
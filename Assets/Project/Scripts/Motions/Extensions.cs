using UnityEngine;
using DG.Tweening;

namespace MagicalShooter.Motions
{
    public static class AutoMotionExtensiton
    {
        public static void DoMove(this IAutoMotion autoMotion, Transform transform, Vector2 forward)
        {
            var sequence = DOTween.Sequence();
            foreach (var motion in autoMotion.Motions)
            {
                sequence.Append(motion.ToSequence(transform, forward, autoMotion.Speed));
            }
            autoMotion.NowMotion = sequence;
            sequence
                .Play()
                .OnComplete(() => autoMotion.DoMove(transform, forward));
        }
    }
}
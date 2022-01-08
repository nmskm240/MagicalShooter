using UnityEngine;
using DG.Tweening;

namespace Shooting.Motions
{
    public static class AutoMotionExtensiton
    {
        public static void DoMove(this IAutoMotion autoMotion, Transform transform)
        {
            var sequence = DOTween.Sequence();
            foreach (var motion in autoMotion.Motions)
            {
                sequence.Append(motion.ToSequence(transform, autoMotion.Speed));
            }
            sequence
                .Play()
                .OnComplete(() => autoMotion.DoMove(transform));
        }
    }
}
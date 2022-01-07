using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Shooting.Motions
{
    [CreateAssetMenu(fileName = "PathRoute", menuName = "Shooting/Motions/PathRoute", order = 0)]
    public class PathRoute : MotionData
    {
        [SerializeField]
        private List<Vector2> _path;

        public override Sequence ToSequence(Transform transform, float speed)
        {
            var path = _path
                .Select(path => (Vector3)(path * transform.up))
                .ToArray();
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOPath(path, ToSpeed(speed), PathType.CatmullRom, PathMode.TopDown2D)
                        .SetEase(_ease)
                        .SetRelative(true));
            return sequence;
        }
    }
}
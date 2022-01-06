using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Shooting.Motions
{
    [CreateAssetMenu(fileName = "Motion", menuName = "Shooting/Motion", order = 0)]
    public class Motion : ScriptableObject
    {
        [SerializeField]
        private List<Vector2> _path;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private Ease _ease = Ease.Linear;

        public Sequence ToSequence(Transform transform, float speed)
        {
            var path = _path.Select(path => (Vector3)(path * transform.up) + transform.position).ToArray();
            var playSpeed = _speed / speed;
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOPath(path, playSpeed, PathType.CatmullRom, PathMode.TopDown2D)
                .SetEase(_ease));
            return sequence;
        }
    }
}
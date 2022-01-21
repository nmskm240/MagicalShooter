using System.Collections.Generic;
using UnityEngine;

namespace MagicalShooter.Stages
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private Vector2 _startPos;
        [SerializeField]
        private Vector2 _endPos;
        [SerializeField]
        private List<Transform> _transforms;

        private void Update()
        {
            foreach (var transform in _transforms)
            {
                transform.Translate(-_speed, 0, 0);
                if (transform.position.x <= _endPos.x)
                {
                    transform.position = _startPos;
                }
            }
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Shooting.Motions;

namespace Shooting.Characters.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Shooting/EnemyData", order = 0)]
    public class EnemyData : CharacterData, IAutoMotion
    {
        [SerializeField]
        private List<MotionData> _motions;

        public IEnumerable<MotionData> Motions { get { return _motions; } }
        public Sequence NowMotion { get; set; }
    }
}
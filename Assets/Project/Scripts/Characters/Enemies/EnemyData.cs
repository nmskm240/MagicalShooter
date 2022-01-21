using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using MagicalShooter.Motions;

namespace MagicalShooter.Characters.Enemies
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "MagicalShooter/EnemyData", order = 0)]
    public class EnemyData : CharacterData, IAutoMotion
    {
        [SerializeField]
        private List<MotionData> _motions;

        public IEnumerable<MotionData> Motions { get { return _motions; } }
        public Sequence NowMotion { get; set; }
    }
}
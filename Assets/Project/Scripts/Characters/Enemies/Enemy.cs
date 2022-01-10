using UnityEngine;
using UniRx;
using Shooting.Motions;
using Shooting.Utils;

namespace Shooting.Characters.Enemies
{
    [RequireComponent(typeof(EnemyView))]
    public class Enemy : Character<EnemyData, EnemyView>
    {
        protected override void Start()
        {
            base.Start();
            _model.DoMove(transform);
        }
    }
}
using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Shooting.Weapons;

namespace Shooting.Characters.Players
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerView))]
    public class Player : Character<PlayerData, PlayerView>
    {
        [SerializeField]
        private Weapon _weapon;

        private void Start()
        {
            var moveInputStream = this.UpdateAsObservable()
                .Select(_ => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            this.FixedUpdateAsObservable()
                .WithLatestFrom(moveInputStream, (_, input) => input)
                .Subscribe(input =>
                {
                    _rigidbody.velocity = input.normalized;
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKey(KeyCode.Space))
                .ThrottleFirst(TimeSpan.FromSeconds(0.5f))
                .Subscribe(_ =>
                {
                    _weapon.Fire();
                });
        }
    }
}
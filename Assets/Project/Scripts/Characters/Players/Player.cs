using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Shooting.Spells;

namespace Shooting.Characters.Players
{
    [RequireComponent(typeof(PlayerView))]
    public class Player : Character<PlayerData, PlayerView>
    {
        [SerializeField]
        private Spell _spell;

        protected override void Start()
        {
            base.Start();
            var min = Camera.main.ViewportToWorldPoint(Vector2.zero);
            var max = Camera.main.ViewportToWorldPoint(Vector2.one);
            var moveInputStream = this.UpdateAsObservable()
                .Select(_ => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
            this.FixedUpdateAsObservable()
                .WithLatestFrom(moveInputStream, (_, input) => input)
                .Select(input => input.normalized * Time.deltaTime * _model.Speed)
                .Subscribe(vector => 
                {
                    var pos = (Vector2)transform.position;
                    var moved = pos + vector;
                    var x = Mathf.Clamp(moved.x, min.x, max.x);
                    var y = Mathf.Clamp(moved.y, min.y, max.y);
                    var clamped = new Vector2(x - pos.x, y - pos.y);
                    transform.Translate(clamped);
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKey(KeyCode.Space))
                .ThrottleFirst(TimeSpan.FromSeconds(0.5f))
                .Subscribe(_ => _spell.Fire());
        }
    }
}
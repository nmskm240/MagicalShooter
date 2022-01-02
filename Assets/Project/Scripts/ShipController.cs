using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    [SerializeField]
    private Weapon _weapon;
    protected Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

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
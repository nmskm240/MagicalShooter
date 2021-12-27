using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField, Range(1, 5)]
    private float _speedCompensation = 0.1f;
    [SerializeField, Range(0.25f, 1)]
    private float _fireInterval = 1;
    [SerializeField]
    private GameObject _bullet;
    private float _time;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_fireInterval < _time && Input.GetKey(KeyCode.Space))
        {
            _time = 0;
            Fire();
        }
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var dir = new Vector2(x, y).normalized;
        _rigidbody.velocity = dir * _speedCompensation;
    }

    private void Fire()
    {
        Instantiate(_bullet, transform.position, transform.rotation);
    }
}
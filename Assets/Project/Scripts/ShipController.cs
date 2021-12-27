using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField, Range(1, 5)]
    private float _speedCompensation = 0.1f;
    [SerializeField, Range(0.25, 1)]
    private float _fireInterval = 1;
    [SerializeField]
    private GameObject _bullet;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Move(x, y);
        if(_fireInterval < _time && Input.GetKey(KeyCode.Space)) 
        {
            _time = 0;
            Fire();
        }
    }

    private void Move(float x, float y)
    {
        var speed = new Vector3(x, y, 0);
        transform.position += speed.normalized * Time.deltaTime * _speedCompensation;
    }

    private void Fire()
    {
        Instantiate(_bullet, transform.position, Quaternion.identity);
    }
}
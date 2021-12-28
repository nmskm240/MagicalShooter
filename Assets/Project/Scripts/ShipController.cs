using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private ShipData _data;
    [SerializeField]
    private GameObject _bullet;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_data.FireRate < _time && Input.GetKey(KeyCode.Space))
        {
            _time = 0;
            Fire();
        }
    }

    private void FixedUpdate()
    {
        foreach(var motion in _data.Motions)
        {
            transform.position += motion.Play(_data.Speed);
        }
    }

    private void Fire()
    {
        Instantiate(_bullet, transform.position, transform.rotation);
    }
}
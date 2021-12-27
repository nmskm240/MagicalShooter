using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField, Range(0.25f, 0.05f)]
    private float _speedCompensation = 0.1f;

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Move(x, y);
    }

    private void Move(float x, float y)
    {
        var speed = new Vector3(x, y, 0);
        transform.position += speed.normalized * _speedCompensation;
    }
}
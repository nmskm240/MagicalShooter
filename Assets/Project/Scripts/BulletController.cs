using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private BulletData _data;

    private void Update()
    {
        foreach(var motion in _data.Motions)
        {
            transform.position += motion.Play(_data.Speed);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
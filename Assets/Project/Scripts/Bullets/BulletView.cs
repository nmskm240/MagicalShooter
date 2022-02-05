using UnityEngine;

namespace MagicalShooter.Bullets
{
    public class BulletView : MonoBehaviour
    {
        public void ChangeBaseAngle()
        {
            var value = gameObject.layer == LayerMask.NameToLayer("PlayersBullet") ? 0 : 180;
            transform.rotation = Quaternion.AngleAxis(value, Vector3.up);
        }
    }
}
using System;
using System.Linq;
using UnityEngine;

namespace Shooting.Spells
{
    [CreateAssetMenu(fileName = "Spell", menuName = "Shooting/Spell/N-Way", order = 0)]
    public class NWay : Spell
    {
        [SerializeField, Range(2, 128)]
        private int _wayNumber;
        [SerializeField, Range(0, 360)]
        private float _angle;

        public override void Active(GameObject activator)
        {
            var y = activator.CompareTag("Player") ? 0.0f : 180.0f;
            var angleRange = Mathf.Deg2Rad * _angle;
            var bulletLayer = LayerMask.NameToLayer(activator.tag + "sBullet");
            for(var i = 0; i < _wayNumber; i++)
            {
                var index = BulletCount % (i + 1);
                var bullet = Bullets.ElementAtOrDefault(Mathf.Clamp(index, 0, BulletCount - 1));
                var span = angleRange / (_wayNumber - 1);
                var baseAngle = 0.5f * angleRange;
                var theta = span * i - baseAngle;
                bullet.layer = bulletLayer;
                bullet.transform.position = activator.transform.position;
                bullet.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * theta, Vector3.forward);
                bullet.transform.parent = null;
            }
        }
    }
}
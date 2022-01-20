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

        protected override void OnActived(GameObject activator)
        {
            var angleRange = Mathf.Deg2Rad * _angle;
            for(var i = 0; i < _wayNumber; i++)
            {
                var index = BulletCount % (i + 1);
                var bullet = CreateBulletAt(index);
                var span = angleRange / (_wayNumber - 1);
                var baseAngle = 0.5f * angleRange;
                var theta = span * i - baseAngle;
                bullet.transform.position = activator.transform.position;
                bullet.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * theta, Vector3.forward);
                bullet.transform.parent = null;
            }
        }
    }
}
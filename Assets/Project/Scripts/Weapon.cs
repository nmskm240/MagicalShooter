using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Shooting.Utils;

namespace Shooting.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<Factory> _ports;

        public void Fire()
        {
            foreach (var bullet in _ports.Select(port => port.Create()))
            {
                bullet.transform.parent = null;
            }
        }
    }
}
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

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
using UnityEngine;

namespace Shooting.Utils
{
    [System.Serializable]
    public class Factory : Object
    {
        [SerializeField]
        private GameObject _origin;

        public GameObject Create()
        {
            return Instantiate(_origin);
        }
    }
}
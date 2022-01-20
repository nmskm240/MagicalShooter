using UnityEngine;

namespace Shooting.Bullets
{
    [CreateAssetMenu(fileName = "BulletDataSet", menuName = "Shooting/BulletDataSet", order = 0)]
    public class BulletDataSet : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private BulletData _model;

        public GameObject Prefab { get { return _prefab; } }
        public BulletData Model { get { return _model; } }
    }
}
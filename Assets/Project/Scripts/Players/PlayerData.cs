using UnityEngine;

namespace Shooting.Ships
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Shooting/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _detail;
        [SerializeField]
        private int _hp;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _fireRate;

        public string Name { get { return _name; } }
        public string Detail { get { return _detail; } }
        public int HP { get { return _hp; } }
        public float Speed { get { return _speed; } }
        public float FireRate { get { return _fireRate; } }
    }
}
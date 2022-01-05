using UnityEngine;

namespace Shooting.Characters.Players
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Shooting/PlayerData", order = 0)]
    public class PlayerData : CharacterData
    {
        [SerializeField]
        private float _fireRate;

        public float FireRate { get { return _fireRate; } }
    }
}
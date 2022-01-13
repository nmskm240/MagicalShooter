using UnityEngine;

namespace Shooting.Spells
{
    public class Spell : MonoBehaviour
    {
        [SerializeField]
        private SpellData _model;

        public void Active()
        {
            foreach (var bullet in _model.Bullets)
            {
                bullet.transform.parent = null;
                bullet.transform.position = transform.position;
            }
        }
    }
}
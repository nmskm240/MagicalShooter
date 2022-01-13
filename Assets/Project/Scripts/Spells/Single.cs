using UnityEngine;

namespace Shooting.Spells
{
    [CreateAssetMenu(fileName = "Spell", menuName = "Shooting/Spell/Single", order = 0)]
    public class Single : Spell
    {
        public override void Active(GameObject shooter)
        {
            foreach(var bullet in Bullets)
            {
                bullet.transform.position = shooter.transform.position;
                bullet.transform.parent = null;
            }
        }
    }
}
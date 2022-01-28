using UnityEngine;

namespace MagicalShooter.Spells
{
    [CreateAssetMenu(fileName = "Spell", menuName = "MagicalShooter/Spell/Single", order = 0)]
    public class Single : Spell
    {
        protected override void OnActived(GameObject activator)
        {
            for(var i = 0; i < BulletCount; i++)
            {
                var bullet = CreateBulletAt(i);
                bullet.transform.position = activator.transform.position;
            }
        }
    }
}
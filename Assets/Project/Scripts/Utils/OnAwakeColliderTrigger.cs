using UnityEngine;

namespace MagicalShooter.Utils
{
    public class OnAwakeColliderTrigger : MonoBehaviour
    {
        private void Awake()
        {
            foreach (var collider in GetComponentsInChildren<Collider2D>())
            {
                collider.isTrigger = true;
            }
        }
    }
}
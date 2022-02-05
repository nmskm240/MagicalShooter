using UnityEngine;

namespace MagicalShooter.Utils
{
    public class OnBecameInvisibleDestroy : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
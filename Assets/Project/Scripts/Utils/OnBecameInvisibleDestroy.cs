using UnityEngine;

namespace Shooting.Utils
{
    public class OnBecameInvisibleDestroy : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace Shooting.Utils
{
    public class OnParticleStoppedDestroy : MonoBehaviour
    {
        private void OnParticleSystemStopped()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
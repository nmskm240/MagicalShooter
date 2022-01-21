using UnityEngine;

namespace MagicalShooter.Utils
{
    public class OnParticleStoppedDestroy : MonoBehaviour
    {
        private void OnParticleSystemStopped()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
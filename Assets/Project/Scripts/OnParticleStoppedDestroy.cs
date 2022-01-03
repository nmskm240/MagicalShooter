using UnityEngine;

public class OnParticleStoppedDestroy : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        Destroy(transform.parent.gameObject);
    }
}
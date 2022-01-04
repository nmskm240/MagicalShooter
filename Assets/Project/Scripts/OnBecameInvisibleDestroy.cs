using UnityEngine;

public class OnBecameInvisibleDestroy : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
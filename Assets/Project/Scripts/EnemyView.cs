using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _explosionParticle;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Explosion()
    {
        _explosionParticle.Play();
        _renderer.sprite = null;
    }
}
using UnityEngine;

namespace MagicalShooter.Characters
{
    public abstract class CharacterView : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        [SerializeField]
        private ParticleSystem _explosionParticle;

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
}
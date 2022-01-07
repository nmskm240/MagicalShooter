using UnityEngine;

namespace Shooting.Characters
{
    public abstract class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;
        [SerializeField]
        private ParticleSystem _explosionParticle;

        public void Explosion()
        {
            _explosionParticle.Play();
            _renderer.sprite = null;
        }
    }
}
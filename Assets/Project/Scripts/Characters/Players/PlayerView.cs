using UnityEngine;

namespace MagicalShooter.Characters.Players
{
    public class PlayerView : CharacterView
    {
        [SerializeField]
        private GameObject _gameOverPanel;

        protected override void Awake()
        {
            base.Awake();
            _gameOverPanel.SetActive(false);
        }

        public void ShowGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}
using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace MagicalShooter
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameOverPanel;
        [SerializeField]
        private GameObject _titles;
        private static GameManager _instance;
        private Subject<Unit> _onGameStart = new Subject<Unit>();
        private Subject<Unit> _onGameOver = new Subject<Unit>();

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    var previous = FindObjectOfType(typeof(GameManager));
                    if (previous)
                    {
                        Debug.LogWarning("Initialized twice. Don't use MidiBridge in the scene hierarchy.");
                        _instance = (GameManager)previous;
                    }
                    else
                    {
                        var go = new GameObject("__GameManager");
                        _instance = go.AddComponent<GameManager>();
                        go.hideFlags = HideFlags.HideInHierarchy;
                    }
                }
                return _instance;
            }
        }
        public IObservable<Unit> OnGameStart { get { return _onGameStart; } }
        public IObservable<Unit> OnGameOver { get { return _onGameOver; } }

        private void Awake()
        {
            _titles.SetActive(true);
            _gameOverPanel.SetActive(false);
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Take(1)
                .Subscribe(_ => 
                {
                    _titles.SetActive(false);
                    _onGameStart.OnNext(Unit.Default);
                });
            _onGameOver
                .Subscribe(_ => 
                {
                    _gameOverPanel.SetActive(true);
                });
        }

        public void GameOver()
        {
            _onGameOver.OnNext(Unit.Default);
        }
    }
}
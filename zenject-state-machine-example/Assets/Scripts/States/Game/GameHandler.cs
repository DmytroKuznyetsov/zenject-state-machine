using System;
using Core;
using States.Game.Services;
using States.Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace States.Game
{
    public class GameHandler: MonoBehaviour
    {
        [SerializeField] private Button FinishGame;
        [SerializeField] private Text Count;
        private StateMachine _stateMachine;
        private ILocalGameProgressService _localGameProgressService;
        private GameProgress _progress;

        [Inject]
        public void Construct(StateMachine stateMachine, ILocalGameProgressService localGameProgressService)
        {
            _localGameProgressService = localGameProgressService;
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            var existingProgress = _localGameProgressService.LoadProgress();
            _progress = existingProgress ?? new GameProgress();
            Count.text = _progress.count.ToString();
            FinishGame.onClick.AddListener(OnFinishGame);
        }

        private void OnFinishGame()
        {
            _progress.count++;
            _localGameProgressService.SaveProgress(_progress);
            _stateMachine.Enter<MainState>();
        }
    }
}
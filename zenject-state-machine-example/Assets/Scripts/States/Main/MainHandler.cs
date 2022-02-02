using System;
using Core;
using Services;
using States.Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace States.Main
{
    public class MainHandler : MonoBehaviour
    {
        [SerializeField] private Button playGame;

        private StateMachine _stateMachine;

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            playGame.onClick.AddListener(PlayGame);
        }

        private void PlayGame()
        {
            _stateMachine.Enter<GameState>();
        }

        private void OnDestroy()
        {
            playGame.onClick.RemoveAllListeners();
        }
    }
}
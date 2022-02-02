using Core;
using Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace States.Game
{
    public class GameState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoadService _sceneLoadService;
        
        public GameState(StateMachine stateMachine, ISceneLoadService sceneLoadService)
        {
            _stateMachine = stateMachine;
            _sceneLoadService = sceneLoadService;
        }

        public void Exit()
        {
        }

        public async void Enter()
        {
            await _sceneLoadService.LoadSceneAsync("Game");

            var handle = Addressables.LoadAssetAsync<GameObject>("GameCanvas");
            var prefab = await handle.Task;
            Object.Instantiate(prefab);

        }
    }
}
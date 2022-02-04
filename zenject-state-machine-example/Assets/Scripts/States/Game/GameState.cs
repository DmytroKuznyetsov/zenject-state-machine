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
        private readonly IInjectedPrefabsService _injectedPrefabsService;

        public GameState(StateMachine stateMachine, ISceneLoadService sceneLoadService, IInjectedPrefabsService injectedPrefabsService)
        {
            _stateMachine = stateMachine;
            _sceneLoadService = sceneLoadService;
            _injectedPrefabsService = injectedPrefabsService;
        }

        public void Exit()
        {
        }

        public async void Enter()
        {
            await _sceneLoadService.LoadSceneAsync("Game");

            var handle = Addressables.LoadAssetAsync<GameObject>("GameCanvas");
            var prefab = await handle.Task as Object;
            _injectedPrefabsService.InstantiatePrefab(prefab);
            // Object.Instantiate(prefab);

        }
    }
}
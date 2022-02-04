using System;
using System.Collections.Generic;
using Services;
using States;
using States.Game;
using States.Main;

namespace Core
{
    public class StateMachine
    {
        private readonly IInjectedPrefabsService _injectedPrefabsService;
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public StateMachine(ISceneLoadService sceneLoadService, IInjectedPrefabsService injectedPrefabsService)
        {
            _injectedPrefabsService = injectedPrefabsService;
            var mainState = new MainState(
                this,
                sceneLoadService
            );

            var gameState = new GameState(
                this,
                sceneLoadService,
                injectedPrefabsService
            );

            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(StartupState)] = new StartupState(this),
                [typeof(MainState)] = mainState,
                [typeof(GameState)] = gameState
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
using Core;
using Services;

namespace States.Main
{
    public class MainState: IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoadService _sceneLoadService;

        public MainState(StateMachine stateMachine, ISceneLoadService sceneLoadService)
        {
            _stateMachine = stateMachine;
            _sceneLoadService = sceneLoadService;
        }

        public void Exit()
        {
        }

        public async void Enter()
        {
            await _sceneLoadService.LoadSceneAsync("Main");
        }
    }
}
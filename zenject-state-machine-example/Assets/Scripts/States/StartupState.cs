using Core;
using States.Main;

namespace States
{
    public class StartupState : IState
    {
        private readonly StateMachine _stateMachine;

        public StartupState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _stateMachine.Enter<MainState>();
        }
    }
}
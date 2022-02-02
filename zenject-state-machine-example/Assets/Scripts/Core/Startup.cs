using States;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Startup: MonoBehaviour
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _stateMachine.Enter<StartupState>();
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        private SceneLoader _sceneLoader;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services, ICoroutineRunner coroutineRunner, DialogWindow dialogWindow, TMPro.TMP_Text _domenText)
        {
            _sceneLoader = sceneLoader;
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, _sceneLoader, services, coroutineRunner, _domenText),
                [typeof(NetworkRequestState)] = new NetworkRequestState(coroutineRunner, this),
                [typeof(DiaglogWindowState)] = new DiaglogWindowState(dialogWindow),
                [typeof(GameLoopState)] = new GameLoopState(coroutineRunner)
            };
        }

    private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;

        public void Enter<TState>() where TState : class, IState
        {
            Debug.Log("Enter");
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            IPayLoadedState<TPayLoad> state = ChangeState<TState>();
            state.Enter(payLoad);
        }
    }
}



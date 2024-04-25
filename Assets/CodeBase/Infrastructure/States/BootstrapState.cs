using Assets.CodeBase;
using System;
using TMPro;
using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly TMP_Text domenText;

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services, ICoroutineRunner coroutineRunner, TMP_Text domenText)
    {
        _gameStateMachine = gameStateMachine;
        _services = services;
        _coroutineRunner = coroutineRunner;
        this.domenText = domenText;
        _sceneLoader = sceneLoader;
    }


    public void Enter()
    {
        CheckInternetConnection();
    }

    public void Exit()
    {
    }

    private void CheckInternetConnection()
    {
        RegisterServices();
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            _gameStateMachine.Enter<DiaglogWindowState>();
        }
        else
            _gameStateMachine.Enter<NetworkRequestState>();
    }

    private void RegisterServices()
    {
        var loadingService = new LoadingService(domenText);
        _services.RigisterSingle(new SceneLoader(_coroutineRunner));
        _services.RigisterSingle(loadingService);
        _services.RigisterSingle(new WebView());
        _services.RigisterSingle(new WebRequest(loadingService));
        loadingService.Load();
    }
}

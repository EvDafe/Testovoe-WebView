using Assets.CodeBase;

public class NetworkRequestState : IState
{
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly GameStateMachine _gameStateMachine;

    public NetworkRequestState(ICoroutineRunner coroutineRunner, GameStateMachine gameStateMachine)
    {
        _coroutineRunner = coroutineRunner;
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        AllServices.Container.Single<WebRequest>().RequestSended += OnRequest;
        _coroutineRunner.StartCoroutine(AllServices.Container.Single<WebRequest>().GetRequest("https://dat095.ru/ninjalevel.php"));
    }

    private void OnRequest()
    {
        if (AllServices.Container.Single<LoadingService>().Progress.Data != null)
        {
            if (DataValidate(AllServices.Container.Single<LoadingService>().Progress.Data))
                AllServices.Container.Single<WebView>().ShowUrlFullScreen(AllServices.Container.Single<LoadingService>().Progress.Data.link);
            else
                _gameStateMachine.Enter<GameLoopState>();
        }
    }

    public void Exit()
    {

    }

    private bool DataValidate(OnlineData data) =>
        data.description == "Yes" && data.rules.Contains("FILTERED") == false;
}

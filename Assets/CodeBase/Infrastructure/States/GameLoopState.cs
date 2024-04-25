public class GameLoopState : IState
{
    private readonly ICoroutineRunner coroutineRunner;

    public GameLoopState(ICoroutineRunner coroutineRunner)
    { 
        this.coroutineRunner = coroutineRunner;
    }


    public void Enter()
    {
        AllServices.Container.Single<SceneLoader>().Load("GameScene");
    }

    public void Exit()
    {
    }
}
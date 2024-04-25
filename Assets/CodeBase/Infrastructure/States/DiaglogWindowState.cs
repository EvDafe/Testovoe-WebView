public class DiaglogWindowState : IState
{
    private readonly DialogWindow _window;

    public DiaglogWindowState(DialogWindow window)
    {
        _window = window;
    }

    public void Enter()
    {
        _window.Show();
    }

    public void Exit()
    {

    }
}

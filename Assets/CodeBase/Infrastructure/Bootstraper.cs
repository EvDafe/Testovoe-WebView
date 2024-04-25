using Assets.CodeBase;
using TMPro;
using UnityEngine;

public class Bootstraper : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private DialogWindow _dialogWindow;
    [SerializeField] private DialogWindow _exitDialogWindow;
    [SerializeField] private TMP_Text _domenText;

    private GameStateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(_exitDialogWindow);
        DontDestroyOnLoad(this);
        _stateMachine = new(new SceneLoader(this), AllServices.Container, this, _dialogWindow, _domenText);
        _stateMachine.Enter<BootstrapState>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _exitDialogWindow.Show();
        }
    }
}

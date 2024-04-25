using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    public GameObject _window;

    public void Show()
    {
        Debug.Log("Show");
        _window.SetActive(true);
    }

    public void Hide() =>
        _window.SetActive(false);

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
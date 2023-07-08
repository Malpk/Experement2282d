using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSwitcher : MonoBehaviour
{
    [SerializeField] private int _mainIdScene;
    [Header("Reference")]
    [SerializeField] private GameMode _mode;
    [SerializeField] private DataSaver _dataSave;
    [SerializeField] private PlayerSwitcher _palyer;
    [SerializeField] private InterfaceSwitcher _interface;

    public void RestartGame()
    {
        _mode.Play();
        _palyer.Reset();
        _interface.SwitchMenu(MenuType.HUD);
    }

    public void CompliteGame()
    {
        _mode.Stop();
        _interface.SwitchMenu(MenuType.DeadMenu);
    }

    public void ExitToMain()
    {
        _palyer.Reset();
        _dataSave.Save();
        SceneManager.LoadScene(_mainIdScene);
    }

}

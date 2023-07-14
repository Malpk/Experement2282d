using UnityEngine;
using UnityEngine.SceneManagement;

public class GameArea : MonoBehaviour
{
    [SerializeField] private int _sceneId;
    [Header("Reference")]
    [SerializeField] private PlayerController _controller;
    [SerializeField] private UIMenu _cheakMenu;
    [SerializeField] private DataSaver _saver;
    [SerializeField] private ExitArea[] _exits;
    [SerializeField] private EnemySpawner _spawner;

    private int _countEnemy = 0;

    private void OnEnable()
    {
        foreach (var exit in _exits)
        {
            exit.OnExit += ShowCheakMenu;
        }
    }

    private void OnDisable()
    {
        foreach (var exit in _exits)
        {
            exit.OnExit -= ShowCheakMenu;
        }
    }

    public void UpdateState(int enemy)
    {
        _countEnemy = enemy;
        if(_countEnemy > 0 || _spawner.IsActive)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        foreach (var exit in _exits)
        {
            exit.Open();
        }
    }

    private void Close()
    {
        foreach (var exit in _exits)
        {
            exit.Close();
        }
    }

    private void ShowCheakMenu()
    {
        _controller.enabled = false;
        _cheakMenu.Show();
    }

    public void CanelExit()
    {
        _controller.enabled = true;
        _cheakMenu.Hide();
    }

    public void ExitToSafeZone()
    {
        _saver.Save();
        SceneManager.LoadScene(_sceneId);
    }

}

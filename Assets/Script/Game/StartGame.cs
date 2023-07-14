using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private int _sceneLoad;
    [Header("Reference")]
    [SerializeField] private DataSaver _dataSaver;
    [SerializeField] private UIMenu _startMenu;
    [SerializeField] private PlayerController _controller;

    public void LoadLvl()
    {
        _dataSaver.Save();
        SceneManager.LoadScene(_sceneLoad);
    }

    public void Canel()
    {
        _startMenu.Hide();
        _controller.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _startMenu.Show();
            _controller.enabled = false;
        }
    }
}

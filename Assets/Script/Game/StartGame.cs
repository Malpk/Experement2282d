using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameController _controller;
    [SerializeField] private UIMenu _startMenu;

    public void LoadLvl()
    {
        
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

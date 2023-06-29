using UnityEngine;
using UnityEngine.UI;

public class DeadMenu : UIMenu
{
    [SerializeField] private float _fadeDuration;
    [SerializeField] private Image _backGround;
    [SerializeField] private GameSwitcher _game;

    public void Restart()
    {
        _game.RestartGame();
    }

    public void ExitToMain()
    {
        
    }
}

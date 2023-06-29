using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InterfaceSwitcher _interface;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = _player.transform.position;
    }

    public void RestartGame()
    {
        _player.Reset();
        _player.transform.position = _startPosition;
        _interface.SwitchMenu(MenuType.HUD);
    }

    public void CompliteGame()
    {
        _interface.SwitchMenu(MenuType.DeadMenu);
    }

}

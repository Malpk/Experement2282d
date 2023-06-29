using UnityEngine;

public class GameSwitcher : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private PlayerSwitcher _palyer;
    [SerializeField] private InterfaceSwitcher _interface;

    public void RestartGame()
    {
        _spawner.Reset();
        _spawner.Play();
        _palyer.Reset();
        _interface.SwitchMenu(MenuType.HUD);
    }

    public void CompliteGame()
    {
        _spawner.Stop();
        _interface.SwitchMenu(MenuType.DeadMenu);
    }

}

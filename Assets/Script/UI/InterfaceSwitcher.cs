using UnityEngine;

public class InterfaceSwitcher : MonoBehaviour
{
    [SerializeField] private UIMenu[] _menu;

    public void CloseOpenInterface()
    {
        foreach (var menu in _menu)
        {
            if (menu.IsShow)
            {
                menu.SwitchState();
            }
        }
    }

    public void OpenMenu()
    {
    }

    public void CloseMenu()
    {
        foreach (var menu in _menu)
        {
            if (menu.IsShow)
            {
                return;
            }
        }
    }
}

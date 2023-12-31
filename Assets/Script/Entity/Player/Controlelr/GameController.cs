using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIMenu _skillMenu;
    [SerializeField] private GunMenu _gunMenu;
    [SerializeField] private PlayerController _controller;

    private UIMenu _openMenu;
    private IMenu _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_menu == null || _gunMenu.IsShow)
            {
                SwitchState(_gunMenu, false);
            }
            else
            {
                SwitchState(_menu.Menu);
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
            SwitchState(_skillMenu);
    }

    public void SetMenu(IMenu menu)
    {
        if(_menu != null)
            _menu.Menu.Hide();
        _menu = menu;
    }

    public void SetMode(bool mode)
    {
        enabled = mode;
        _controller.enabled = mode;
    }

    private void SwitchState(UIMenu menu, bool blockPlayer = true)
    {
        if (menu == _openMenu)
        {
            if (_openMenu.Hide())
            {
                _openMenu = null;
                _controller.enabled = true;
            }
        }
        else if(!_openMenu)
        {
            _openMenu = menu;
            _openMenu.Show();
            _controller.enabled = !blockPlayer;
        }
    }

}

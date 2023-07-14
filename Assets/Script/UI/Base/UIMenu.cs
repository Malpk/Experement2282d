using UnityEngine;
using UnityEngine.Events;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private MenuType _type;
    [Header("Event")]
    [SerializeField] private UnityEvent _onShow;
    [SerializeField] private UnityEvent _onHide;

    private UIMenu _subMenu;

    public bool IsShow => gameObject.activeSelf;
    public MenuType Type => _type;

    public bool SwitchState()
    {
        if (!gameObject.activeSelf)
        {
            Show();
            return true;
        }
        else
        {
            return Hide();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _onShow.Invoke();
    }

    public void ShowSubMenu(UIMenu menu)
    {
        if (_subMenu)
            _subMenu.Hide();
        _subMenu = menu;
        _subMenu.Show();
    }

    public bool Hide()
    {
        if (!_subMenu)
        {
            gameObject.SetActive(false);
            _onHide.Invoke();
            return true;
        }
        else
        {
            _subMenu.Hide();
            _subMenu = null;
            return false;
        }
    }

}

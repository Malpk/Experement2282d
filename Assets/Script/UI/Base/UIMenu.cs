using UnityEngine;
using UnityEngine.Events;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private MenuType _type;
    [Header("Reference")]
    [SerializeField] private UnityEvent _onShow;
    [SerializeField] private UnityEvent _onHide;

    public bool IsShow => gameObject.activeSelf;
    public MenuType Type => _type;

    public void SwitchState()
    {
        if (gameObject.activeSelf)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _onShow.Invoke();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _onHide.Invoke();
    }

}

using UnityEngine;
using UnityEngine.Events;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent _onShow;
    [SerializeField] private UnityEvent _onHide;

    public bool IsShow => gameObject.activeSelf;

    public void SwitchState()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            _onHide.Invoke();
        }
        else
        {
            gameObject.SetActive(true);
            _onShow.Invoke();
        }
    }
}

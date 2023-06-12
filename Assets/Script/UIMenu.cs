using UnityEngine;
using UnityEngine.Events;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private UnityEvent _onShow;

    public bool IsShow => gameObject.activeSelf;

    public void SwitchState()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            _onShow.Invoke();
        }
    }
}

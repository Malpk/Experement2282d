using UnityEngine;

public class InteractiveMenu : MonoBehaviour, IInteractive
{
    [Header("Reference")]
    [SerializeField] private UIMenu _shopMenu;
    [SerializeField] private GameObject _lable;

    private bool _isBlock = false;

    public bool IsBlock => _isBlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _lable.SetActive(true);
            enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _lable.SetActive(false);
            enabled = false;
        }
    }

    public void Interactive(bool input)
    {
        if (input)
        {
            _shopMenu.SwitchState();
            _isBlock = _shopMenu.IsShow;
        }
    }
}

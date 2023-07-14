using UnityEngine;

public class InteractiveMenu : MonoBehaviour, IMenu
{
    [Header("Reference")]
    [SerializeField] private UIMenu _shopMenu;
    [SerializeField] private GameObject _lable;

    public UIMenu Menu => _shopMenu;

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
}

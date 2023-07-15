using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    [SerializeField] private GameController _controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IMenu menu))
        {
            _controller.SetMenu(menu);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IMenu menu))
        {
            _controller.SetMenu(null);
        }
    }
}

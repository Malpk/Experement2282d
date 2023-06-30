using UnityEngine;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    public event System.Action OnExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            OnExit?.Invoke();
        }
    }

    public void Open()
    {
        _collider.isTrigger = true;
    }

    public void Close()
    {
        _collider.isTrigger = false;
    }
}

using UnityEngine;

public class PoolItem : MonoBehaviour
{
    public event System.Action<PoolItem> OnDelete;

    public void Delete()
    {
        gameObject.SetActive(false);
        OnDelete?.Invoke(this);
    }
}

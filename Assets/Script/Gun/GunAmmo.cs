using UnityEngine;

[RequireComponent(typeof(PoolItem))]
public class GunAmmo : MonoBehaviour
{
    [SerializeField] private int _ammo;
    [SerializeField] private GunType _gunType;

    private PoolItem _poolItem;

    public int Ammo => _ammo;
    public GunType GunType => _gunType;

    private void Awake()
    {
        _poolItem = GetComponent<PoolItem>();
    }

    public void Pick()
    {
        _poolItem.Delete();
    }
}

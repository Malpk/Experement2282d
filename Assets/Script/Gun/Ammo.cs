using UnityEngine;

public class Ammo : DataItem
{
    [SerializeField] private int _countAmmo;
    [SerializeField] private GunType _gunAmmo;
    [Header("Reference")]
    [SerializeField] private PoolItem _item;

    public GunType Gun => _gunAmmo;
    public int CountAmmo => _countAmmo;

    public void Pick(Transform holder)
    {
        gameObject.SetActive(false);
        transform.parent = holder;
    }

    public void Delete()
    {
        _item.Delete();
    }
}

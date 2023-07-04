using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private DataItem[] _items;
    [Header("Reference")]
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GunHolder _holder;

    public bool Buy(DataItem item)
    {
        if (_wallet.TryGiveMoney(item.Price))
        {
            return true;
        }
        return false;
    }

    public void PutGun(DataItem gun)
    {
    }

}

using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopItem[] _items;
    [Header("Reference")]
    [SerializeField] private ShopUI _shopMenu;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GunHolder _holder;

    private ShopItem _select;

    private void Awake()
    {
        Load();
    }

    private void OnEnable()
    {
        _shopMenu.OnSelect += SelectData;
    }

    private void OnDisable()
    {
        _shopMenu.OnSelect -= SelectData;
    }

    public void SelectData(ShopItem item)
    {
        _select = item;
    }

    public void Buy()
    {
        if (_select != null)
        {
            if (_wallet.TryGiveMoney(_select.Content.Price))
            {
                _select.IsBuy = true;
                _shopMenu.BuySelect();
            }
        }
    }

    public void AddGun(DataItem gun)
    {
        _holder.AddGun(gun.GetComponent<Gun>());
    }

    private void Load()
    {
        foreach (var item in _items)
        {
            _shopMenu.AddShopItem(item);
        }
    }

}

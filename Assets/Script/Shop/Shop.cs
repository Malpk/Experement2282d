using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopItem[] _items;
    [Header("Reference")]
    [SerializeField] private ShopUI _shopMenu;
    [SerializeField] private Wallet _wallet;


    private ShopItem _select;

    private List<DataItem> _buyList = new List<DataItem>();

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

    public string Save()
    {
        var data = new ShopData();
        data.BuyList = new int[_buyList.Count];
        for (int i = 0; i < _buyList.Count; i++)
        {
            data.BuyList[i] = _buyList[i].ID;
        }
        return JsonUtility.ToJson(data);
    }

    public void Load(List<DataItem> buyList)
    {
        _buyList.AddRange(buyList);
        foreach (var item in _items)
        {
            if (buyList.Contains(item.Content))
            {
                buyList.Remove(item.Content);
                item.IsBuy = true;
            }
        }
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
                _buyList.Add(_select.Content);
            }
        }
    }

    private void Load()
    {
        foreach (var item in _items)
        {
            _shopMenu.AddShopItem(item);
        }
    }

}

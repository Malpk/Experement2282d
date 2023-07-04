using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UIMenu
{
    [Header("Reference")]
    [SerializeField] private GoodsUI _goodsPrefab;
    [SerializeField] private Transform _contentHolder;
    [SerializeField] private ShopButtonSwitcher _switcher;

    private GoodsUI _selectGoods;

    private List<GoodsUI> _goods = new List<GoodsUI>();

    public event System.Action<ShopItem> OnSelect;

    private void OnEnable()
    {
        foreach (var goods in _goods)
        {
            goods.OnSelect += Select;
        }
    }

    private void OnDisable()
    {
        foreach (var goods in _goods)
        {
            goods.OnSelect -= Select;
        }
    }

    public GoodsUI AddShopItem(ShopItem item)
    {
        var goods = Instantiate(_goodsPrefab.gameObject, _contentHolder).
            GetComponent<GoodsUI>();
        goods.SetItem(item);
        _goods.Add(goods);
        return goods;
    }

    public void BuySelect()
    {
        _selectGoods.Buy();
        UpdateButton(_selectGoods);
    }

    private void Select(GoodsUI goods)
    {
        if (_selectGoods)
            _selectGoods.DeSelect();
        _selectGoods = goods;
        OnSelect?.Invoke(goods.Content);
        UpdateButton(goods);
    }

    private void UpdateButton(GoodsUI select)
    {
        if (!select.IsBuy)
        {
            _switcher.ShowBuyButton();
        }
        else
        {
            _switcher.ShowChooseButton();
        }

    }

}

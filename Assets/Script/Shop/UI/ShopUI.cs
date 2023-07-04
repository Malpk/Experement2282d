using UnityEngine;

public class ShopUI : UIMenu
{
    [Header("Reference")]
    [SerializeField] private Shop _shop;
    [SerializeField] private GoodsUI[] _goods;

    private GoodsUI _selectGoods;

    private void OnEnable()
    {
        foreach (var good in _goods)
        {
            good.OnSelect += Select;
        }
    }

    private void OnDisable()
    {
        foreach (var good in _goods)
        {
            good.OnSelect -= Select;
        }
    }

    private void Select(GoodsUI goods)
    {
        if (_selectGoods)
            _selectGoods.DeSelect();
        _selectGoods = goods;
    }

    private void Buy()
    {
        _selectGoods.Buy(
            _shop.Buy(_selectGoods.Content));
    }

    public void TakeGun()
    {
        
    }
}

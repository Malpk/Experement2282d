using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GoodsUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private float _durationAnimation;
    [SerializeField] private Color _selectColor;
    [SerializeField] private DataItem _item;
    [Header("SelfReferences")]
    [SerializeField] private Image _icon;
    [SerializeField] private Image _select;
    [SerializeField] private TextPrefix _price;
    [SerializeField] private TextMeshProUGUI _name;

    private bool _isSelect;
    private Color _baseColor;

    public event System.Action<GoodsUI> OnSelect;

    public bool IsBuy { get; private set; } = false;
    public DataItem Content => _item;

    private void Awake()
    {
        _baseColor = _select.color;
    }

    private void OnValidate()
    {
        if (_item)
            SetItem(_item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _select.DOColor(_selectColor, _durationAnimation);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isSelect)
            DeSelect();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isSelect = true;
        OnSelect?.Invoke(this);
    }

    public void DeSelect()
    {
        _isSelect = false;
        _select.DOColor(_baseColor, _durationAnimation);
    }

    public void SetItem(DataItem item)
    {
        _item = item;
        _name.text = item.Name;
        _icon.sprite = item.Icon;
        _price.SetText(item.Price.ToString());
    }

    public void Buy(bool input)
    {
        IsBuy = input;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private DataItem _content;
    [Header("Reference")]
    [SerializeField] private Image _icon;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private CanvasGroup _cavasGroup;

    private Transform _cell;

    public DataItem Content => _content;

    private void OnValidate()
    {
        if(_content)
            SetContent(_content);
    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
    }

    public void Intilizate(Canvas canvas)
    {
        _canvas = canvas;
    }

    public void SetContent(DataItem item)
    {
        _icon.sprite = item.Icon;
        _content = item;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _cell = transform.parent;
        transform.SetParent(_canvas.transform);
        _cavasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += (Vector3)eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _cavasGroup.blocksRaycasts = true;
        if (transform.parent == _canvas.transform)
        {
            transform.parent = _cell;
            Reset();
        }
    }

}

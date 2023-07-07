using UnityEngine;
using UnityEngine.EventSystems;

public class CellUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private SlotUI _content;

    public event System.Action<SlotUI, SlotUI> OnReplace;
    public event System.Action <DataItem> OnUpdateContent;

    public SlotUI Content => _content;

    private void OnValidate()
    {
        if(_content)
            SetSlot(_content);
    }

    public void SetSlot(SlotUI slot)
    {
        _content = slot;
        if (slot)
        {
            _content.transform.parent = transform;
            _content.Reset();
            OnUpdateContent?.Invoke(slot.Content);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out SlotUI slot))
        {
            OnReplace?.Invoke(_content, slot);
            SetSlot(slot);
        }
    }

}

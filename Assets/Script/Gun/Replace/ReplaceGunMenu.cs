using UnityEngine;

public class ReplaceGunMenu : UIMenu
{
    [SerializeField] private GunHolder _holder;
    [Header("CanvasReference")]
    [SerializeField] private SlotUI _prefabSlot;
    [SerializeField] private CellUI _replaceCell;
    [SerializeField] private ReplaceCell[] _cells;
    [SerializeField] private Canvas _canvas;

    private SlotUI _replaceSlot;

    public void Awake()
    {
        var slots = _holder.Slots;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].Gun)
            {
                if (slots[i].Gun.TryGetComponent(out DataItem item))
                {
                    _cells[i].SetSlot(CreateSlot(item, _cells[i].transform));
                }
            }
            _cells[i].SetGunSlot(slots[i]);
        }
    }

    public void SetReplce(DataItem gun)
    {
        if (_replaceSlot)
        {
            _replaceSlot.SetContent(gun);
        }
        else
        {
            _replaceCell.SetSlot(CreateSlot(gun, _replaceCell.transform));
        }
    }

    private SlotUI CreateSlot(DataItem item, Transform cell)
    {
        var slot = Instantiate(_prefabSlot.gameObject, cell).
            GetComponent<SlotUI>();
        slot.Intilizate(_canvas);
        slot.SetContent(item);
        return slot;
    }

    private CellUI GetEmpityCell()
    {
        foreach (var cell in _cells)
        {
            if (!cell.Content)
            {
                return cell;
            }
        }
        return null;
    }
}

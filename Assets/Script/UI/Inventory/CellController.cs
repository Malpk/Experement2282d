using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private CellUI[] _cells;

    private void OnEnable()
    {
        foreach (var cell in _cells)
        {
            cell.OnReplace += DropSlot;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.OnReplace -= DropSlot;
        }
    }

    private void DropSlot(SlotUI from, SlotUI to)
    {
        var cell = GetCell(to);
        cell.SetSlot(from);
    }

    private CellUI GetCell(SlotUI slot)
    {
        foreach (var cell in _cells)
        {
            if (cell.Content == slot)
            {
                return cell;
            }
        }
        return null;
    }

}

using UnityEngine;
using UnityEngine.Events;


public class GunCorusel : MonoBehaviour
{
    [SerializeField] private GunCell[] _cells;
    [Header("Event")]
    [SerializeField] private UnityEvent<Gun> _onSelect; 

    private GunCell _selectCell;

    public int Count => _cells.Length;

    private void Update()
    {
        var cell = Getcell(
            GetPosition());
        if (_selectCell != cell)
            SelectCell(cell);
    }

    public void RemoveGun(Gun gun)
    {
        foreach (var cell in _cells)
        {
            if (cell.Content == gun)
            {
                cell.SetGun(null);
            }
        }
    }

    private void SelectCell(GunCell cell)
    {
        if (_selectCell)
        {
            if (_selectCell.IsSelect)
                _selectCell.Deselect();
        }
        cell.Select();
        _selectCell = cell;
        if(cell.Content)
            _onSelect.Invoke(cell.Content);
    }

    private GunCell Getcell(Vector2 position)
    {
        var cell = _cells[0];
        var distance = Vector2.Distance(position, cell.transform.localPosition);
        for (int i = 1; i < _cells.Length; i++)
        {
            var newDistance = Vector2.Distance(position, _cells[i].transform.localPosition);
            if (distance > newDistance)
            {
                cell = _cells[i];
                distance = newDistance;
            }
        }
        return cell;
    }

    private Vector3 GetPosition()
    {
        var size = new Vector3(Screen.width, Screen.height);
        return Input.mousePosition - size / 2;
    }
}

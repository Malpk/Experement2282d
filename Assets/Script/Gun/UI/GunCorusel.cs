using UnityEngine;

public class GunCorusel : MonoBehaviour
{
    [SerializeField] private GunHolder _holder;
    [SerializeField] private GunCell[] _cells;

    private GunCell _selectCell;

    private void Update()
    {
        var cell = Getcell(
            GetPosition());
        if (_selectCell != cell)
            SelectCell(cell);
    }

    public void Load()
    {
        for (int i = 0; i < _cells.Length && i < _holder.Guns.Length; i++)
        {
            _cells[i].SetGun(_holder.Guns[i]);
        }
        if (_selectCell)
            _selectCell.Select();
    }

    public bool AddGun(Gun gun)
    {
        foreach (var cell in _cells)
        {
            if (!cell.Content)
            {
                cell.SetGun(gun);
                return true;
            }
        }
        return false;
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
            _holder.SetGun(cell.Content);
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

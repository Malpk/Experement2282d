using UnityEngine;

public class DataHolder : MonoBehaviour
{
    [SerializeField] private DataItem[] _items;

    public DataItem GetItem(int id)
    {
        foreach (var item in _items)
        {
            if (id == item.ID)
            {
                return item;
            }
        }
        return null;
    }
}

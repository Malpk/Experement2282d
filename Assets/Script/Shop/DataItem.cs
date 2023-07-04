using UnityEngine;

public class DataItem : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int ID => _id;
    public int Price => _price;
    public string Name => _name;
    public Sprite Icon => _icon;
}

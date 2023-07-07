using UnityEngine;

[System.Serializable]
public class ItemSpawnSlot
{
#if UNITY_EDITOR
    [SerializeField] string _name;
#endif
    [SerializeField] private float _probility;
    [SerializeField] private Pool _pool;

    public float Probillity => _probility;

    public DataItem Create()
    {
        var item = _pool.Create().GetComponent<DataItem>();
        return item;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolItem _prefab;

    private List<PoolItem> _pools = new List<PoolItem>();

    public void AddItem(PoolItem item)
    {
        item.OnDelete += Return;
    }

    public PoolItem Create(Transform transform = null)
    {
        var item = Instatiate(transform);
        item.OnDelete += Return;
        return item;
    }

    private PoolItem Instatiate(Transform transform)
    {
        if (_pools.Count > 0)
        {
            var pool = _pools[0];
            pool.gameObject.SetActive(true);
            pool.transform.parent = transform;
            _pools.Remove(pool);
            return pool;
        }
        return Object.Instantiate(_prefab.gameObject, transform).GetComponent<PoolItem>();
    }

    private void Return(PoolItem pool)
    {
        pool.OnDelete -= Return;
        pool.transform.parent = transform;
        pool.transform.localPosition = Vector3.zero;
        _pools.Add(pool);
    }
}

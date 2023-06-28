using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCleaner : MonoBehaviour
{
    [SerializeField] private float _deleteDistance;
    [SerializeField] private float _timeCheak;
    [Header("SceneReference")]
    [SerializeField] private Transform _target;

    private Coroutine _corotine;

    private List<PoolItem> _items = new List<PoolItem>();

    public void Start()
    {
        if(_corotine == null)
            _corotine = StartCoroutine(ClearUpdate());
    }

    public void Clear()
    {
        _items.Clear();
    }

    public void AddItem(PoolItem poolItem)
    {
        _items.Add(poolItem);
    }

    private IEnumerator ClearUpdate()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_timeCheak);
            var delete = GetDeleteItems();
            foreach (var item in delete)
            {
                item.Delete();
                _items.Remove(item);
            }
        }
        _corotine = null;
    }

    private List<PoolItem> GetDeleteItems()
    {
        var list = new List<PoolItem>();
        foreach (var item in _items)
        {
            var distance = Vector2.Distance(item.transform.position, _target.position);
            if (distance >= _deleteDistance)
            {
                list.Add(item);
            }
        }
        return list;
    }
}

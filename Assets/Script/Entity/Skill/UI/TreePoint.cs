using UnityEngine;
using System.Collections.Generic;

public class TreePoint : MonoBehaviour
{
    [SerializeField] private List<Edge> _edgs;
    [SerializeField] private List<TreePoint> _parents;

    public event System.Action OnUpdateMode;

    public void Activate()
    {
        SetMode(true);
    }

    public void Deactivate()
    {
        SetMode(false);
    }

    private void SetMode(bool mode)
    {
        SetEdge(mode);
        OnUpdateMode?.Invoke();
    }

    private void SetEdge(bool mode)
    {
        foreach (var edge in _edgs)
        {
            edge.SetMode(mode);
        }
    }
}

using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class TreePoint : MonoBehaviour
{
    [SerializeField] private List<Edge> _edgs;
    [SerializeField] private List<TreePoint> _parents;
    [Header("Event")]
    [SerializeField] private UnityEvent<bool> _onChangeMode;

    public event System.Action OnUpdateMode;

    public bool IsMode { get; private set; }

    private void OnEnable()
    {
        foreach (var point in _parents)
        {
            point.OnUpdateMode += UpdatePoint;
        }
    }

    private void OnDisable()
    {
        foreach (var point in _parents)
        {
            point.OnUpdateMode -= UpdatePoint;
        }
    }

    public void Activate()
    {
        SetMode(true);
    }

    public void Deactivate()
    {
        SetMode(false);
    }

    public void SetReady(bool mode)
    {
        _onChangeMode.Invoke(mode);
    }

    private void SetMode(bool mode)
    {
        IsMode = mode;
        SetEdge(mode);
        OnUpdateMode?.Invoke();
    }

    private void UpdatePoint()
    {
        if (CheakParentReady())
            SetReady(true);
    }

    private bool CheakParentReady()
    {
        foreach (var point in _parents)
        {
            if (!point.IsMode)
                return false;
        }
        return true;
    }

    private void SetEdge(bool mode)
    {
        foreach (var edge in _edgs)
        {
            edge.SetMode(mode);
        }
    }
}

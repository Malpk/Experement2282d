using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [Header("GunSetting")]
    [SerializeField] private List<Gun> _guns;
    [Header("Reference")]
    [SerializeField] private GunMenu _gunMenu;
    [SerializeField] private GunController _controller;

    public void Reset()
    {
        foreach (var gun in _guns)
        {
            if (gun)
                gun.Reset();
        }
    }

    private void Awake()
    {
        SetGun(_guns[0]);
        foreach (var gun in _guns)
        {
            _gunMenu.AddGun(gun);
        }
    }

    public void SetGun(Gun gun)
    {
        _controller.SetGun(gun);
    }

    public bool AddGun(Gun gun)
    {
        if (_gunMenu.CountCell > _guns.Count)
        {
            _guns.Add(gun);
            _gunMenu.AddGun(gun);
            return true;
        }
        return false;
    }

    public void RemoveGun(Gun gun)
    {
        _guns.Remove(gun);
        _gunMenu.RemoveGun(gun);
    }

    public void SwitchGunMenu(bool input)
    {
        if (input)
            _gunMenu.SwitchState();
    }
}

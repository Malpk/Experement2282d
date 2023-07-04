using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIMenu))]
public class GunMenu : MonoBehaviour
{
    [SerializeField] private GunHolder _holder;
    [SerializeField] private GunCorusel _corusel;

    private UIMenu _menu;

    private void Awake()
    {
        _menu = GetComponent<UIMenu>();
    }

    public void AddGun()
    {
        
    }
}

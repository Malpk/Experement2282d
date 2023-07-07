using UnityEngine;

public class GunMenu : UIMenu
{
    [SerializeField] private GunCorusel _corusel;
    [SerializeField] private ReplaceGunMenu _replaceMenu;

    public int CountCell => _corusel.Count;

    public void AddGun(Gun gun)
    {
    }

    public void RemoveGun(Gun gun)
    {
        _corusel.RemoveGun(gun);
    }
}

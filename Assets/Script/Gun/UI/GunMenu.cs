using UnityEngine;

public class GunMenu : UIMenu
{
    [SerializeField] private GunCorusel _corusel;

    public int CountCell => _corusel.Count;

    public void RemoveGun(Gun gun)
    {
        _corusel.RemoveGun(gun);
    }
}

using UnityEngine;

[System.Serializable]
public class GunSlot
{
    [SerializeField] private Gun _gun;
    [SerializeField] private GunCell _coruselSlot;

    public Gun Gun => _gun;

    public void Intilizate()
    {
        _coruselSlot.SetGun(_gun);
    }

    public void SetGun(DataItem gun)
    {
        _gun = gun.GetComponent<Gun>();
        _coruselSlot.SetGun(_gun);
    }

}

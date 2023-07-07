using UnityEngine;

[System.Serializable]
public class GunSlot
{
    [SerializeField] private Gun _gun;
    [SerializeField] private GunCell _coruselSlot;

    private Transform _holder;

    public Gun Gun => _gun;

    public void Intilizate(Transform gunHolder)
    {
        _holder = gunHolder;
        if(_gun)
            _coruselSlot.SetGun(_gun);
    }

    public void SetGun(DataItem gun)
    {
        if(_gun)
            Object.Destroy(_gun.gameObject);
        if (gun)
        {
            _gun = Object.Instantiate(gun.gameObject, _holder).
                GetComponent<Gun>();
            _gun.gameObject.SetActive(false);
        }
        else
        {
            _gun = null;
        }
        _coruselSlot.SetGun(_gun);
    }

}

using UnityEngine;

public class Gun : DataItem
{
    [SerializeField] private GunType _gunType;
    [Header("Hand")]
    [SerializeField] private Transform _rightHandPoint;
    [SerializeField] private Transform _leftHandPoint;
    [Header("Reference")]
    [SerializeField] private Sprite _gunIcon;
    [SerializeField] private GunSound _sound;
    [SerializeField] private GunMagazine _magazine;
    [SerializeField] private ShootPoint _shootPoint;

    private bool _pressGun = false;

    public GunType GunType => _gunType;
    public Transform RightHandPoint => _rightHandPoint;
    public Transform LeftHandPoint => _leftHandPoint;

    public event System.Action<int, int> OnUpdateMagazine;

    public void Reset()
    {
        _magazine.Reset();
    }

    public bool Shoot(bool input)
    {
        input = input && !_magazine.IsReload;
        if (_magazine.CurrteMagazine > 0)
        {
            if (_shootPoint.Shoot(input))
            {
                _magazine.CurrteMagazine--;
                _sound.Shoot();
                UpdateGun();
                return true;
            }
        }
        else if (input)
        {
            if (!_pressGun)
            {
                _sound.EmptyMagazine();
                _pressGun = true;
            }
        }
        else
        {
            _pressGun = false;
        }
        return false;
    }

    public void Reload(bool input)
    {
        if (input)
        {
            if (_magazine.Reload(UpdateGun))
            {
                _sound.Reload();
            }
        }
    }

    public bool AddAmmo(int ammo)
    {
        if (_magazine.AddAmmo(ammo))
        {
            UpdateGun();
            return true;
        }
        return false;
    }

    public void UpdateGun()
    {
        OnUpdateMagazine?.Invoke(_magazine.CurrteMagazine, _magazine.CurretAmmo);
    }

}

using UnityEngine;

public class Gun : MonoBehaviour
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
    public Sprite Icon => _gunIcon;
    public GunMagazine Magazine => _magazine;
    public Transform RightHandPoint => _rightHandPoint;
    public Transform LeftHandPoint => _leftHandPoint; 



    public bool Shoot(bool input)
    {
        if (_magazine.CurrteMagazine > 0)
        {
            if (_shootPoint.Shoot(input))
            {
                _magazine.CurrteMagazine--;
                _sound.Shoot();
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

    public void Reload(bool input, System.Action actin)
    {
        if (input)
        {
            if (!_magazine.Reload(actin))
            {
                _sound.Reload();
            }
        }
    }

    public bool AddAmmo(int ammo)
    {
        return _magazine.AddAmmo(ammo);
    }

}

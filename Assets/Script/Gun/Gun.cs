using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunType _gunType;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _magazinSize;
    [Header("ShootSetting")]
    [SerializeField] private float _spread;
    [SerializeField] private float _spreadDistance;
    [SerializeField] private float _timeReload;
    [SerializeField] private float _shootDelay;
    [Header("Events")]
    [SerializeField] private UnityEvent<int, int> OnUpdateGunInfo;
    [Header("Reference")]
    [SerializeField] private Pool _projectile;
    [SerializeField] private Sprite _gunIcon;
    [SerializeField] private GunSound _sound;
    [SerializeField] private Transform _shootPoint;

    private int _curretAmmo = 50;
    private int _currteMagazine;
    private float _progress = 0f;

    private System.Action State;

    public bool IsReadyShoot { get; private set; } = true;
    public GunType GunType => _gunType;
    public Sprite Icon => _gunIcon;

    private void Awake()
    {
        enabled = false;
        _currteMagazine = _magazinSize;
        _curretAmmo = _maxAmmo;
        UpdateGunInfo();
    }

    public void Shoot()
    {
        if (IsReadyShoot)
        {
            if (_currteMagazine > 0)
            {
                _currteMagazine--;
                var bullet = _projectile.Create().GetComponent<Projectile>();
                bullet.transform.position = _shootPoint.position;
                bullet.transform.right = GetDiraction();
                bullet.Play();
                _sound.Shoot();
                UpdateGunInfo();
            }
            else
            {
                _sound.EmptyMagazine();
            }
            Play(ShootDealyState);
        }
    }

    public void Relaod()
    {
        _sound.Reload();
        Play(ReloadState);
    }

    public bool AddAmmo(int ammo)
    {
        if (_curretAmmo < _maxAmmo)
        {
            _curretAmmo = Mathf.Clamp(_curretAmmo + ammo, _curretAmmo, _maxAmmo);
            return true;
        }
        return false;
    }

    private void Update()
    {
        State();
    }
    private void Play(System.Action state)
    {
        _progress = 0f;
        enabled = true;
        IsReadyShoot = false;
        State = state;
    }

    private void ShootDealyState()
    {
        _progress += Time.deltaTime / _shootDelay;
        if(_progress >= 1)
        {
            enabled = false;
            IsReadyShoot = true;
        }
    }

    private void ReloadState()
    {
        _progress += Time.deltaTime / _timeReload;
        if (_progress >= 1)
        {
            enabled = false;
            IsReadyShoot = true;
            _curretAmmo += _currteMagazine;
            if (_curretAmmo > _magazinSize)
            {
                _currteMagazine = _magazinSize;
                _curretAmmo -= _magazinSize;
            }
            else
            {
                _currteMagazine = _curretAmmo;
                _curretAmmo = 0;
            }
            UpdateGunInfo();
        }
    }

    private void UpdateGunInfo()
    {
        OnUpdateGunInfo?.Invoke(_currteMagazine, _curretAmmo);
    }

    private Vector2 GetDiraction()
    {
        var right = _shootPoint.right * _spreadDistance;
        var up = _shootPoint.up * Random.Range(-_spread, _spread);
        return right + up;
    }

}

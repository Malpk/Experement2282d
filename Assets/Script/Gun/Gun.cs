using UnityEngine;

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
    [Header("Hand")]
    [SerializeField] private Transform _rightHandPoint;
    [SerializeField] private Transform _leftHandPoint;
    [Header("Reference")]
    [SerializeField] private Pool _projectile;
    [SerializeField] private Sprite _gunIcon;
    [SerializeField] private GunSound _sound;
    [SerializeField] private Transform _shootPoint;

    private bool _isReadyShoot  = true;
    private float _progress = 0f;

    private System.Action State;

    public event System.Action OnReload;

    public int CurretAmmo { get; private set; } = 50;
    public int CurrteMagazine { get; private set; }
    public GunType GunType => _gunType;
    public Sprite Icon => _gunIcon;
    public Transform RightHandPoint => _rightHandPoint;
    public Transform LeftHandPoint => _leftHandPoint; 


    private void Awake()
    {
        enabled = false;
        CurrteMagazine = _magazinSize;
        CurretAmmo = _maxAmmo;
    }

    public bool Shoot()
    {
        if (_isReadyShoot)
        {
            if (CurrteMagazine > 0)
            {
                CurrteMagazine--;
                var bullet = _projectile.Create().GetComponent<Projectile>();
                bullet.transform.position = _shootPoint.position;
                bullet.transform.right = GetDiraction();
                bullet.Play();
                _sound.Shoot();
            }
            else
            {
                _sound.EmptyMagazine();
            }
            Play(ShootDealyState);
            return true;
        }
        return false;
    }

    public void Reload()
    {
        _sound.Reload();
        Play(ReloadState);
    }

    public bool AddAmmo(int ammo)
    {
        if (CurretAmmo < _maxAmmo)
        {
            CurretAmmo = Mathf.Clamp(CurretAmmo + ammo, CurretAmmo, _maxAmmo);
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
        _isReadyShoot = false;
        State = state;
    }

    private void ShootDealyState()
    {
        _progress += Time.deltaTime / _shootDelay;
        if(_progress >= 1)
        {
            enabled = false;
            _isReadyShoot = true;
        }
    }

    private void ReloadState()
    {
        _progress += Time.deltaTime / _timeReload;
        if (_progress >= 1)
        {
            enabled = false;
            _isReadyShoot = true;
            CurretAmmo += CurrteMagazine;
            if (CurretAmmo > _magazinSize)
            {
                CurrteMagazine = _magazinSize;
                CurretAmmo -= _magazinSize;
            }
            else
            {
                CurrteMagazine = CurretAmmo;
                CurretAmmo = 0;
            }
            OnReload?.Invoke();
        }
    }

    private Vector2 GetDiraction()
    {
        var right = _shootPoint.right * _spreadDistance;
        var up = _shootPoint.up * Random.Range(-_spread, _spread);
        return right + up;
    }

}

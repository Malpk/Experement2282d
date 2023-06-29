using UnityEngine;

public class GunMagazine : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _magazinSize;
    [SerializeField] private float _timeReload;

    private float _progress = 0f;
    private System.Action _reloadAction;

    public int CurrteMagazine { get; set; }
    public int CurretAmmo { get; private set; } = 50;
    public bool IsReload { get; private set; } = false;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        enabled = false;
        CurrteMagazine = _magazinSize;
        CurretAmmo = _maxAmmo;
    }

    private void OnEnable()
    {
        if (IsReload)
        {
            IsReload = false;
            enabled = false;
        }
    }

    private void Update()
    {
        _progress += Time.deltaTime / _timeReload;
        if (_progress >= 1)
        {
            enabled = false;
            IsReload = false;
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
            _reloadAction();
        }
    }


    public bool Reload(System.Action actin)
    {
        if (!IsReload)
        {
            _progress = 0f;
            enabled = true;
            IsReload = true;
            _reloadAction = actin;
            return true;
        }
        return false;
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
}

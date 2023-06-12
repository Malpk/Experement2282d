using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _spread;
    [SerializeField] private float _spreadDistance;
    [SerializeField] private float _timeReload;
    [SerializeField] private float _shootDelay;
    [Header("Reference")]
    [SerializeField] private Pool _projectile;
    [SerializeField] private GunSound _sound;
    [SerializeField] private Transform _shootPoint;

    private float _progress = 0f;
    private System.Action State;

    public bool IsReadyShoot { get; private set; } = true;

    private void Awake()
    {
        enabled = false;
    }

    public void Shoot()
    {
        if (IsReadyShoot)
        {
            var bullet = _projectile.Create().GetComponent<Projectile>();
            bullet.transform.position = _shootPoint.position;
            bullet.transform.right = GetDiraction();
            bullet.Play();
            _sound.Shoot();
            Play(ShootDealyState);
        }
    }

    public void Relaod()
    {
        _sound.Reload();
        Play(ReloadState);
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
        }
    }
    private Vector2 GetDiraction()
    {
        var right = _shootPoint.right * _spreadDistance;
        var up = _shootPoint.up * Random.Range(-_spread, _spread);
        return _shootPoint.position + right + up;
    }

}

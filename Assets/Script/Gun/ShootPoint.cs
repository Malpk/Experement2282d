using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private float _shootDelay = 0.5f;
    [SerializeField] private float _spread = 2;
    [Header("SpreadSetting")]
    [SerializeField] private float _spreadDelta = 0.2f;
    [SerializeField] private float _spreadReduceDelta = 0.2f;
    [SerializeField] private float _spreadDistance = 20;
    [Header("Reference")]
    [SerializeField] private Pool _projectile;
    [SerializeField] private Transform _shootPoint;

    private float _progress = 0f;
    private float _curretStread = 0f;

    public bool IsReady { get; private set; } = true;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        _progress += Time.deltaTime / _shootDelay;
        if (_progress >= 1)
        {
            enabled = false;
            IsReady = true;
        }
    }

    public bool Shoot(bool input)
    {
        if (input && IsReady)
        {
            var bullet = _projectile.Create().GetComponent<Projectile>();
            bullet.transform.position = _shootPoint.position;
            bullet.transform.right = GetDiraction();
            bullet.Play();
            IsReady = false;
            enabled = true;
            _progress = 0;
            _curretStread = Mathf.Clamp(_curretStread + _spreadDelta, 0, _spread);
            return true;
        }
        else
        {
            _curretStread = Mathf.Clamp(_curretStread - _spreadReduceDelta * Time.deltaTime,
                0, _curretStread);
        }
        return false;
    }

    private Vector2 GetDiraction()
    {
        var right = _shootPoint.right * _spreadDistance;
        var up = _shootPoint.up * Random.Range(-_curretStread, _curretStread);
        return right + up;
    }
}

using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] private int _height = 5;
    [Header("Reference")]
    [SerializeField] private Camera _hudCamera;
    [SerializeField] private Transform _target;
    [SerializeField] private EntityAnimator _animator;
    [SerializeField] private GameController _controller;

    private float _curretHealth = 0f;

    public event System.Action<float> OnChageHealth;

    private void Start()
    {
        _curretHealth = _height;
    }


    private void Update()
    {
        _target.position = (Vector2)_hudCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Kill()
    {
        enabled = false;
        _animator.Dead();
    }

    public bool TakeDamage(int damage, Transform projectile)
    {
        if (_curretHealth > 0)
        {
            _curretHealth = Mathf.Clamp(_curretHealth - damage, 0, _curretHealth);
            if (_curretHealth == 0)
                Kill();
            UpdateHealth();
            return true;
        }
        return false;
    }

    private void UpdateHealth()
    {
        OnChageHealth?.Invoke(_curretHealth / _height);
    }

}

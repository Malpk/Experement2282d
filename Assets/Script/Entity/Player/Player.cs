using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] private int _height = 5;
    [Header("SceneReference")]
    [SerializeField] private Camera _hudCamera;
    [SerializeField] private Transform _target;
    [Header("SelfReference")]
    [SerializeField] private EntityAnimator _animator;
    [SerializeField] private GameController _controller;

    private float _curretHealth = 0f;

    public event System.Action<float> OnChageHealth;

    public void Reset()
    {
        _curretHealth = _height;
        enabled = true;
        _controller.enabled = true;
    }

    private void Start()
    {
        Reset();
    }


    private void Update()
    {
        _target.position = (Vector2)_hudCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    public void Kill()
    {
        enabled = false;
        _controller.enabled = false;
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

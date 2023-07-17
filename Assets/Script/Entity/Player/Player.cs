using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDamage
{
    [SerializeField] private int _height = 5;
    [Header("SelfReference")]
    [SerializeField] private BodySkillSet _bodySetl;
    [SerializeField] private Rigidbody2D _rigidBody2d;
    [SerializeField] private DamageScreen _screen;
    [SerializeField] private EntityAnimator _animator;
    [SerializeField] private PlayerController _controller;
    [Header("Events")]
    [SerializeField] private UnityEvent _onDead; 

    private float _curretHealth = 0f;

    public event System.Action<float> OnChageHealth;

    public bool IsDead { get; private set; }

    private int Health => _height + _bodySetl.Health;

    public void Reset()
    {
        _curretHealth = Health;
        enabled = true;
        _controller.enabled = true;
        _animator.Dead(false);
        IsDead = false;
        _rigidBody2d.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Start()
    {
        Reset();
    }
    public void Kill()
    {
        enabled = false;
        _controller.enabled = false;
        _animator.Dead();
        IsDead = true;
        _rigidBody2d.bodyType = RigidbodyType2D.Static;
        _onDead.Invoke();
    }

    public bool TakeDamage(int damage, Transform projectile)
    {
        if (_curretHealth > 0)
        {
            _curretHealth = Mathf.Clamp(_curretHealth - damage, 0, _curretHealth);
            _screen?.Hit();
            if (_curretHealth == 0)
                Kill();
            UpdateHealth();
            return true;
        }
        return false;
    }

    private void UpdateHealth()
    {
        OnChageHealth?.Invoke(_curretHealth / Health);
    }

}

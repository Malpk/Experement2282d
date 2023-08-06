using UnityEngine;
using System.Collections;

public class AiEnemy : MonoBehaviour, IDamage
{
    [Min(1)]
    [SerializeField] private int _health;
    [Min(1)]
    [SerializeField] private float _speedMovement;
    [Header("Reference")]
    [SerializeField] private BodyEntity _body;

    private int _curretHealth;

    public event System.Action OnDead;
    public event System.Action<float> OnUpdateHealth;

    private void Reset()
    {
        _health = 1;
        _speedMovement = 1f;
        _body = GetComponent<BodyEntity>();
    }

    private void Awake()
    {
        ResetAi();
    }

    public void Move(Vector2 direction)
    {
        if (!_body.IsHit)
        {
            _body.Move(direction * _speedMovement);
        }
    }

    public void ResetAi()
    {
        enabled = true;
        _curretHealth = _health;
    }
    public void DeadAi()
    {
        enabled = false;
        OnDead?.Invoke();
    }

    public bool TakeDamage(int damage, Vector2 hit = default, Vector2 hitDirection = default)
    {
        if (_curretHealth > 0)
        {
            _curretHealth = Mathf.Clamp(_curretHealth - damage, 0, _curretHealth);
            OnUpdateHealth?.Invoke(_curretHealth / (float)_health);
            if (_curretHealth == 0)
                DeadAi();
            _body.AddHit(hit, hitDirection);
            return true;
        }
        return false;
    }

}

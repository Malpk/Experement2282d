using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private EnemyBrain _brain;
    [SerializeField] private EnemyHealth _health;

    public event System.Action<Enemy> OnDead;

    public bool IsDead { get; private set; } = false;

    public void Reset()
    {
        IsDead = false;
        _health.Reset();
        _brain.Reset();
    }

    private void FixedUpdate()
    {
        _brain.UpdateState();
    }

    public void Dead()
    {
        IsDead = true;
        OnDead?.Invoke(this);
    }

    public void SetTarget(Player target)
    {
        _detect.SetTarget(target);
    }
}

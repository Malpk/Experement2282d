using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private EnemyBrain _brain;
    [SerializeField] private EnemyHealth _health;

    public event System.Action OnDead;

    public void Reset()
    {
        _health.Reset();
    }

    private void Start()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        _brain.UpdateState();
    }

    public void Dead()
    {
        OnDead?.Invoke();
    }

    public void SetTarget(Player target)
    {
        _detect.SetTarget(target);
    }
}

using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private EnemyAttackStats _attackStats;
    [Header("Reference")]
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private EntityAnimator _animator;

    private Vector2 _target => _detect.Target.transform.position;

    public override void Reset()
    {
        _animator.Attack();
    }

    private void OnEnable()
    {
        _animator.OnAttack += Attack;
    }

    private void OnDisable()
    {
        _animator.OnAttack -= Attack;
    }

    public override void UpdateState()
    {
        var distance = Vector2.Distance(transform.position, _target);
        if (distance > _attackStats.Distance || _detect.Target.IsDead)
        {
            CompliteState(StateType.Following);
        }
    }

    private void Attack()
    {
        _detect.Target.
            TakeDamage(_attackStats.Damage, null);
    }

}

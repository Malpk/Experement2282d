using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private EnemyAttackStats _attackStats;
    [Header("Reference")]
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private EnemyAnimator _animator;

    private Player _target;

    public override void Reset()
    {
        _animator.Attack();
        _target = _detect.Target;
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
        if (Vector2.Distance(transform.position, _target.transform.position) > _attackStats.Distance)
        {
            CompliteState(StateType.Following);
        }
    }

    private void Attack()
    {
        _target.TakeDamage(_attackStats.Damage, null);
    }

}

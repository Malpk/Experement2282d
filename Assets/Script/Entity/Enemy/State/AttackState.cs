using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private EnemyAttackStats _attackStats;
    [Header("Reference")]
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private EntityAnimator _animator;

    private bool _isAttack;
    private float _distanceToTarget;
    private float _progress = 0f;

    private Vector2 _target => _detect.Target.transform.position;

    private void OnEnable()
    {
        _animator.OnAttack += HitPlayer;
    }

    private void OnDisable()
    {
        _animator.OnAttack -= HitPlayer;
    }

    public override void Enter()
    {
        _progress = 1f;
        _isAttack = false;
    }

    public override bool UpdateState()
    {
        _distanceToTarget = Vector2.Distance(transform.position, _target);
        if (!_isAttack)
        {
            if(CheakTarget())
                Attack();
        }
        return true;
    }

    public override void Exit()
    {
        Exit(StateType.Following);
    }

    private bool CheakTarget()
    {
        if (_distanceToTarget > _attackStats.Distance || _detect.Target.IsDead)
        {
            _isAttack = true;
            Exit(StateType.Following);
            return false;
        }
        return true;
    }

    private void Attack()
    {
        _progress += Time.fixedDeltaTime / _attackStats.Delay;
        if (_progress >= 1f)
        {
            _progress = 0f;
            _isAttack = true;
            _animator.Attack();
        }
    }

    private void HitPlayer()
    {
        _isAttack = false;
        if (_distanceToTarget < _attackStats.Distance)
        {
            _detect.Target.TakeDamage(_attackStats.Damage, null);
        }
    }


}

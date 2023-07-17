using UnityEngine;
using System.Collections.Generic;

public class FollowingState : EnemyState
{
    [SerializeField] private float _cheakRadius;
    [SerializeField] private float _speedDelta;
    [SerializeField] private float _speedMovement;
    [SerializeField] private Vector2 _speedRange;
    [SerializeField] private EnemyAttackStats _attackStats;
    [Header("Reference")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private EntityAnimator _animator;

    private float _curretVelocity;
    private Vector2 _target => _detect.Target.transform.position;

    public System.Action State;

    public override void Enter()
    {
        State = Following;
        _rigidBody.isKinematic = false;
    }

    public override void Exit()
    {
        _rigidBody.isKinematic = true;
        _rigidBody.velocity = Vector2.zero;
        Exit(StateType.Attack);
    }

    public override bool UpdateState()
    {
        if (!_detect.Target.IsDead)
        {
            if (Vector2.Distance(_rigidBody.position, _target) > _attackStats.Distance - 0.2f)
            {
                _animator.Move();
                State();
                return true;
            }
            else
            {
                Exit();
                return false;
            }
        }
        else
        {
            _animator.Move(false);
            return false;
        }
    }

    private void Following()
    {
        var direction = _target - _rigidBody.position;
        _curretVelocity = Mathf.Clamp(_curretVelocity +  Time.deltaTime * _speedDelta, 0, _speedMovement);
        var closeEnemy = CheakCloseEnemy();
        if (closeEnemy)
        {
            var directionOut = _rigidBody.position - (Vector2)closeEnemy.position;
            var dot = Vector2.Dot(direction, directionOut);
            if (dot <= 0)
            {
                _enemy.Move(directionOut.normalized * _curretVelocity);
                _curretVelocity = (1 + dot) * _curretVelocity;
            }
        }
        else
        {
            FlipBody(direction.x);
            _enemy.Move(direction.normalized * _curretVelocity);
        }
    }

    private Transform CheakCloseEnemy()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _cheakRadius);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                if(!enemy.IsDead)
                    return collider.transform;
            }
        }
        return null;
    }

    private void FlipBody(float direction)
    {
        if (direction != 0)
        {
            var scale = transform.localScale;
            scale.x = (direction > 0 ? 1 : -1) * Mathf.Abs(scale.x);
            _rigidBody.transform.localScale = scale;
        }
    }

}

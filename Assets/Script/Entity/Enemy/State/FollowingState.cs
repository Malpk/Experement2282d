using UnityEngine;

public class FollowingState : EnemyState
{
    [SerializeField] private EnemyAttackStats _attackStats;
    [SerializeField] private Vector2 _speedRange;
    [Header("Reference")]
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private EnemyAnimator _animator;

    private float _speedDelta;
    private Player _target;


    public override void Reset()
    {
        _animator.Move();
        _target = _detect.Target;
    }

    private void Start()
    {
        _speedDelta = Random.Range(_speedRange.x, _speedRange.y);
    }

    public override void UpdateState()
    {
        if (Vector2.Distance(_rigidBody.position, _target.transform.position) > _attackStats.Distance)
        {
            var direction = _target.transform.position.x - _rigidBody.position.x;
            if (direction != 0)
            {
                var scale = transform.localScale;
                scale.x = (direction > 0 ? 1 : -1) * Mathf.Abs(scale.x);
                _rigidBody.transform.localScale = scale;
            }
            var move = Vector2.MoveTowards(_rigidBody.position, _target.transform.position, 
                _speedDelta * Time.fixedDeltaTime);
            _rigidBody.MovePosition(move);
        }
        else
        {
            CompliteState(StateType.Attack);
        }
    }


}

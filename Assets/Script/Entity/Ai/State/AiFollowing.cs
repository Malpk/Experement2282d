using UnityEngine;

public class AiFollowing : AiState
{
    [SerializeField] private float _attackDistance;
    [Header("Reference")]
    [SerializeField] private AiEnemy _aiEnemy;
    [SerializeField] private AiTarget _target;

    private Transform _point;

    private bool _complite = false;

    public override bool IsComplite => _complite;

    public override void Initializate(AiEnemy enemy)
    {
        _aiEnemy = enemy;
    }

    public override void Enter(AiTarget target)
    {
        _complite = false;
        _target = target;
        if (_target.TryGetTarget(out AttackPoint point))
        {
            _point = point.transform;
            point.Enter(_aiEnemy);
        }
        else
        {
            _point = _target.transform;
        }
    }

    public override bool UpdateState()
    {
        var distance = Vector2.Distance(_target.transform.position, _aiEnemy.transform.position);
        Debug.DrawLine(transform.position, _point.position, Color.red);
        if (distance > _attackDistance)
        {
            var direction = _point.position - _aiEnemy.transform.position;
            _aiEnemy.Move(direction.normalized);
            return true;
        }
        else
        {
            Exit();
            return false;
        }
    }

    public override void Exit()
    {

    }

}

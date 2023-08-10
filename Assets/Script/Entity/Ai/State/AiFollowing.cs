using UnityEngine;

public class AiFollowing : AiState
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _radius;
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
    }

    public override bool UpdateState()
    {
        _point = _target.GetTarget(transform.position).transform;
        var distance = Vector2.Distance(_target.transform.position, _aiEnemy.transform.position);
        Debug.DrawLine(transform.position, _point.position, Color.red);
        if (distance > _attackDistance)
        {
            Following();
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

    private void Following()
    {
        var direction = _point.position - _aiEnemy.transform.position;
        _aiEnemy.Move(direction.normalized);
    }

}

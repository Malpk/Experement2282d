using UnityEngine;

public class AiIdleState : AiState
{
    [SerializeField] private float _delay;
    [SerializeField] private AiState _nextState;

    private float _progress = 0f;

    public override bool IsComplite => _progress >= 1f;

    public override void Initializate(AiEnemy enemy)
    {
    }

    public override void Enter(AiTarget target)
    {
        _progress = 0f;
    }

    public override bool UpdateState()
    {
        _progress += Time.fixedDeltaTime / _delay;
        if (_progress >= 1f)
        {
            Exit();
            return false;
        }
        else
        {
            return true;
        }
    }

    public override void Exit()
    {
    }
}

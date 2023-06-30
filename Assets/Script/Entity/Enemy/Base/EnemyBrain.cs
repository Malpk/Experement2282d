using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private StateType _startState;
    [SerializeField] private EnemyState[] _states;
    
    private EnemyState _curretState;

    private void OnEnable()
    {
        foreach (var state in _states)
        {
            state.OnComplite += SwitchState;
        }
    }

    private void OnDisable()
    {
        foreach (var state in _states)
        {
            state.OnComplite -= SwitchState;
        }
    }

    public void Reset()
    {
        SwitchState(_startState);
    }

    private void Start()
    {
        Reset();
    }

    public void UpdateState()
    {
        _curretState.UpdateState();
    }

    public void SwitchState(StateType state)
    {
        var nextState = GetState(state);
        nextState.Reset();
        _curretState = nextState;
    }

    private EnemyState GetState(StateType type)
    {
        foreach (var state in _states)
        {
            if (state.Type == type)
                return state;
        }
        return null;
    }
}

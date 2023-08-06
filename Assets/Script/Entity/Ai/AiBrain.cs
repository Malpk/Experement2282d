using UnityEngine;

public class AiBrain : MonoBehaviour
{
    [SerializeField] private AiTarget _target;
    [SerializeField] private AiEnemy _enemy;
    [SerializeField] private AiState[] _states;

    private AiState _curretState;

    private void OnValidate()
    {
        if(_enemy)
        {
            foreach (var state in _states)
            {
                state?.Initializate(_enemy);
            }
        }
    }

    private void Awake()
    {
        _curretState = _states[0];
        _curretState.Enter(_target);
    }

    private void OnEnable()
    {
        _enemy.OnDead += () => enabled = false;
    }

    private void OnDisable()
    {
        _enemy.OnDead -= () => enabled = false;
    }

    private void FixedUpdate()
    {
        _curretState.UpdateState();
    }

}

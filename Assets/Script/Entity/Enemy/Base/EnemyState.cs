using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private StateType _type;

    public event System.Action<StateType> OnComplite;

    public StateType Type => _type;

    public abstract void Enter();

    public abstract bool UpdateState();

    public abstract void Exit();

    protected void Exit(StateType next)
    {
        OnComplite?.Invoke(next);
    }
}

using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private StateType _type;

    public event System.Action<StateType> OnComplite;

    public StateType Type => _type;

    public abstract void Reset();

    public abstract void UpdateState();

    protected void CompliteState(StateType next)
    {
        OnComplite?.Invoke(next);
    }
}

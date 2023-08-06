using UnityEngine;

public abstract class AiState : MonoBehaviour
{
    public abstract bool IsComplite { get; }

    public abstract void Initializate(AiEnemy enemy);

    public abstract void Enter(AiTarget target);

    public abstract bool UpdateState();

    public abstract void Exit();

}

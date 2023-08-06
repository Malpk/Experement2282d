using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private AiEnemy _enemy;

    public bool IsBusy => _enemy;

    public void Enter(AiEnemy enemy)
    {
        _enemy = enemy;
    }

    public void Exit(AiEnemy enemy)
    {
        if (_enemy == enemy)
            _enemy = null;
    }
}

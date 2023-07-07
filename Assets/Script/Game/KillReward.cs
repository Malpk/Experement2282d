using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class KillReward : MonoBehaviour
{
    [SerializeField] private Vector2Int _reward;
    [Header("Event")]
    [SerializeField] private UnityEvent<int> _onCangeCount;
    [SerializeField] private UnityEvent<Vector2> _onKill;
    [Header("SceneReference")]
    [SerializeField] private Wallet _wallet;

    private List<Enemy> _activeEnemy = new List<Enemy>();

    public int CountEnemy => _activeEnemy.Count;

    public void Reset()
    {
        foreach (var enemy in _activeEnemy)
        {
            enemy.OnDead -= DeleteEnemy;
        }
        _activeEnemy.Clear();
        _onCangeCount.Invoke(_activeEnemy.Count);
    }

    public void AddEnemy(Enemy enemy)
    {
        if (!_activeEnemy.Contains(enemy))
        {
            _activeEnemy.Add(enemy);
            enemy.OnDead += DeleteEnemy;
            _onCangeCount.Invoke(_activeEnemy.Count);
        }
    }

    private void DeleteEnemy(Enemy enemy)
    {
        _wallet.TakeMoney(Random.Range(_reward.x, _reward.y));
        _activeEnemy.Remove(enemy);
        _onKill.Invoke(enemy.transform.position);
        enemy.OnDead -= DeleteEnemy;
        _onCangeCount.Invoke(_activeEnemy.Count);
    }
}

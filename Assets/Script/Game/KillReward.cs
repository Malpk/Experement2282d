using System.Collections.Generic;
using UnityEngine;

public class KillReward : MonoBehaviour
{
    [SerializeField] private int _reward;
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
    }

    public void AddEnemy(Enemy enemy)
    {
        if (!_activeEnemy.Contains(enemy))
        {
            _activeEnemy.Add(enemy);
            enemy.OnDead += DeleteEnemy;
        }
    }

    private void DeleteEnemy(Enemy enemy)
    {
        _wallet.TakeMoney(_reward);
        _activeEnemy.Remove(enemy);
        enemy.OnDead -= DeleteEnemy;
    }
}

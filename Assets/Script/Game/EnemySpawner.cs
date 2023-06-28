using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _countSecond;
    [SerializeField] private Vector2 _spawnDistance;
    [Header("Reference")]
    [SerializeField] private Pool _enemyPool;
    [SerializeField] private Player _target;

    private float _delay = 1f;
    private Coroutine _corotine;
    private List<PoolItem> _activeEnemy = new List<PoolItem>();

    private void OnValidate()
    {
        _delay = 1f / _countSecond;
    }

    public void Reset()
    {
        foreach (var enemy in _activeEnemy)
        {
            enemy.Delete();
        }
    }

    public void Start()
    {
        _delay = 1f / _countSecond;
        if (_corotine == null)
            _corotine = StartCoroutine(SpawnEnemy());
    }


    private IEnumerator SpawnEnemy()
    {
        while (enabled)
        {
            var enemy = Spawn();
            enemy.SetTarget(_target);
            yield return new WaitForSeconds(_delay);
        }
    }

    private Enemy Spawn()
    {
        var enemy = _enemyPool.Create();
        enemy.OnDelete += Delete;
        SetPosition(enemy.transform);
        _activeEnemy.Add(enemy);
        return enemy.GetComponent<Enemy>();
    }

    private void SetPosition(Transform enemy)
    {
        var distance = Random.Range(_spawnDistance.x, _spawnDistance.y);
        var angel = Random.Range(0f, 360f) / Mathf.Deg2Rad;
        var position = new Vector2(Mathf.Cos(angel), Mathf.Sin(angel)) * distance;
        enemy.position = (Vector2)_target.transform.position + position;
    }

    private void Delete(PoolItem enemy)
    {
        _activeEnemy.Remove(enemy);
    }

}

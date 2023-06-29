using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _maxEnemy;
    [SerializeField] private float _countSecond;
    [SerializeField] private Vector2 _spawnDistance;
    [Header("Reference")]
    [SerializeField] private Pool _enemyPool;
    [SerializeField] private Player _target;
    [SerializeField] private KillReward _reward;
    [SerializeField] private PoolCleaner _clener;

    private float _delay = 1f;
    private Coroutine _corotine;

    public void Reset()
    {
        _enemyPool.Reset();
        _clener.Clear();
    }

    private void OnValidate()
    {
        _delay = 1f / _countSecond;
    }

    public void Start()
    {
        Play();
    }

    public void Play()
    {
        enabled = true;
        _delay = 1f / _countSecond;
        if (_corotine == null)
            _corotine = StartCoroutine(SpawnEnemy());
    }

    public void Stop()
    {
        enabled = false;
        StopCoroutine(_corotine);
        _corotine = null;
    }

    private IEnumerator SpawnEnemy()
    {
        while (enabled)
        {
            yield return new WaitWhile(() => _reward.CountEnemy >= _maxEnemy);
            var enemy = Spawn();
            enemy.Reset();
            enemy.SetTarget(_target);
            _reward.AddEnemy(enemy);
            yield return new WaitForSeconds(_delay);
        }
    }

    private Enemy Spawn()
    {
        var item = _enemyPool.Create();
        SetPosition(item.transform);
        var enemy = item.GetComponent<Enemy>();
        enemy.OnDead += (Enemy e) => KillEnemy(e, item);
        return enemy;
    }

    private void KillEnemy(Enemy enemy, PoolItem item)
    {
        _clener.AddItem(item);
        enemy.OnDead -= (Enemy e) => KillEnemy(e, item);
    }

    private void SetPosition(Transform enemy)
    {
        var distance = Random.Range(_spawnDistance.x, _spawnDistance.y);
        var angel = Random.Range(0f, 360f) / Mathf.Deg2Rad;
        var position = new Vector2(Mathf.Cos(angel), Mathf.Sin(angel)) * distance;
        enemy.position = (Vector2)_target.transform.position + position;
    }

}

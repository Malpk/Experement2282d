using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeDestroy;
    [Header("Reference")]
    [SerializeField] private PoolItem _poolItem;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Coroutine _coroutine;

    private void Awake()
    {
        enabled = false;
    }

    public void Play()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(Delete(_timeDestroy));
        enabled = true;
    }

    public void Stop()
    {
        StopAllCoroutines();
        enabled = false;
    }

    private void FixedUpdate()
    {
        var move = transform.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(transform.position + move);
    }

    private IEnumerator Delete(float timeDestroy)
    {
        yield return new WaitForSeconds(timeDestroy);
        _poolItem.Delete();
    }

}

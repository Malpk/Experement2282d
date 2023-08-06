using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeDestroy;
    [SerializeField] private LayerMask _layer;
    [Header("Reference")]
    [SerializeField] private PoolItem _poolItem;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Coroutine _coroutine;

    private void Awake()
    {
        enabled = false;
    }

    private void FixedUpdate()
    {
        var move = transform.right * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(transform.position + move);
        var hit = Physics2D.Linecast(transform.position, transform.position + move, _layer);
        if (hit)
            Attack(hit);
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

    private IEnumerator Delete(float timeDestroy)
    {
        yield return new WaitForSeconds(timeDestroy);
        _poolItem.Delete();
        enabled = false;
    }

    private void Attack(RaycastHit2D hit)
    {
        if (hit.collider.TryGetComponent(out IDamage target))
        {
            if (target.TakeDamage(_damage, hit.point, transform.right))
            {
                Stop();
                _poolItem.Delete();
            }
        }
    }
}

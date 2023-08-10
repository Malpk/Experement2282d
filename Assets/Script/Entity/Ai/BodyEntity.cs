using System.Collections;
using UnityEngine;

public class BodyEntity : MonoBehaviour
{
    [Min(0)]
    [SerializeField] private float _speedMovement;
    [Min(0.5f)]
    [SerializeField] private float _aiRadius;
    [Header("Hit")]
    [Min(0.1f)]
    [SerializeField] private float _timeHit;
    [Min(0.5f)]
    [SerializeField] private float _hitImpulce;
    [SerializeField] private AnimationCurve _curve;
    [Header("Reference")]
    [SerializeField] private DecalBody _decal;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _body;

    private Coroutine _corotine;

    public bool IsHit => _corotine != null;

    private void Reset()
    {
        _aiRadius = 1f;
        _timeHit = 1f;
        _hitImpulce = 1f;
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 direction)
    {
        if (_corotine == null)
        {
            var speed = _speedMovement * Time.fixedDeltaTime;
            if (TryGetDirection(direction, out Vector2 result))
            {
                direction = result;
            }
            _body.MovePosition(_body.position + direction * speed);
        }
    }

    public void MoveToPoint(Vector2 position)
    {
        _body.MovePosition(position);
    }

    public void AddHit(Vector2 hit, Vector2 hitDirection)
    {
        if (_corotine != null)
        {
            StopCoroutine(_corotine);
        }
        _corotine = StartCoroutine(AddForce(hitDirection, _hitImpulce, _timeHit));
        _decal.CreateDecal(hit);
    }

    private IEnumerator AddForce(Vector2 direction, float force, float time)
    {
        var progress = 0f;
        Vector2 start = transform.position;
        while (progress <= 1)
        {
            progress += Time.fixedDeltaTime / time;
            _body.MovePosition(start + direction * _curve.Evaluate(progress) * force);
            yield return new WaitForFixedUpdate();
        }
        _corotine = null;
    }

    private bool TryGetDirection(Vector2 direction, out Vector2 result)
    {
        result = direction;
        var position = _body.position + direction * _speedMovement * Time.fixedDeltaTime;
        var colliders = Physics2D.OverlapCircleAll(position, _aiRadius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<AiEnemy>() && collider != _collider)
            {
                var enemyDirection = position - (Vector2)collider.transform.position;
                var dot = Vector2.Dot(enemyDirection.normalized, direction);
                if(dot < 0)
                {
                    result += enemyDirection.normalized;
                    result.Normalize();
                }
            }
        }
        return result != direction;
    }

    private void GetDirection(Vector2 direction, float move)
    {
        var hits = Physics2D.CircleCastAll(transform.position, _aiRadius, direction, move);

    }
}

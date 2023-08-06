using System.Collections;
using UnityEngine;

public class BodyEntity : MonoBehaviour
{
    [Range(0, 1f)]
    [SerializeField] private float _timeMovement;
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

    private float _progress = 0f;
    private Coroutine _hitCorotine;

    public bool IsHit => _hitCorotine != null;

    private void Reset()
    {
        _aiRadius = 1f;
        _timeMovement = 1f;
        _timeHit = 1f;
        _hitImpulce = 1f;
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 move)
    {
        if (TryGetAi(_aiRadius, move))
            _progress = 0f;
        _progress = Mathf.Clamp01(_progress + Time.fixedDeltaTime / _timeMovement);
        _body.MovePosition(_body.position + move * _progress * Time.fixedDeltaTime);
    }

    public void MoveToPoint(Vector2 position)
    {
        _body.MovePosition(position);
    }

    public void AddHit(Vector2 hit, Vector2 hitDirection)
    {
        if (_hitCorotine != null)
        {
            StopCoroutine(_hitCorotine);
        }
        _hitCorotine = StartCoroutine(AddForce(hitDirection));
        _decal.CreateDecal(hit);
    }

    private IEnumerator AddForce(Vector2 direction)
    {
        var progress = 0f;
        Vector2 start = transform.position;
        while (progress <= 1)
        {
            progress += Time.fixedDeltaTime / _timeHit;
            _body.MovePosition(start + direction * _curve.Evaluate(progress) * _hitImpulce);
            yield return new WaitForFixedUpdate();
        }
        _hitCorotine = null;
    }

    private bool TryGetAi(float radius, Vector2 move)
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<AiEnemy>() && collider != _collider)
            {
                var enemyDirection = collider.transform.position - transform.position;
                var dot = Vector2.Dot(enemyDirection.normalized, move.normalized);
                if(dot > 0)
                    return true;
            }
        }
        return false;
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    [SerializeField] private int _health;
    [SerializeField] private int _damege;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attakDelay;
    [SerializeField] private Vector2 _speedRange;
    [Header("Reference")]
    [SerializeField] private Player _target;
    [SerializeField] private DecalBody _decal;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _body;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Collider2D _collider;

    private int _currethelth = 0;
    private float _progress = 0f;
    private Vector3 _scale;
    private float _speedDelta;

    public System.Action State;

    private void Start()
    {
        _scale = transform.localScale;
        _speedDelta = Random.Range(_speedRange.x, _speedRange.y);
        Reset();
    }

    private void Reset()
    {
        _currethelth = _health;
        transform.localScale = _scale;
        State = MoveState;
        _collider.isTrigger = false;
        _animator.SetBool("move", true);
    }


    private void FixedUpdate()
    {
        State();
    }

    private void MoveState()
    {
        if (Vector2.Distance(_rigidBody.position, _target.transform.position) > _attackDistance)
        {
            var direction = _target.transform.position.x - _rigidBody.position.x;
            if (direction != 0)
            {
                var scale = transform.localScale;
                scale.x = (direction > 0 ? 1 : -1) * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            var move = Vector2.MoveTowards(_rigidBody.position, _target.transform.position, _speedDelta * Time.fixedDeltaTime);
            _rigidBody.MovePosition(move);
        }
        else
        {
            _progress = 1f;
            State = AttackState;
            _animator.SetBool("attack", true);
        }
    }

    private void AttackState()
    {
        if (Vector2.Distance(_rigidBody.position, _target.transform.position) > _attackDistance)
        {
            State = MoveState;
            _animator.SetBool("attack", false);
        }
        else
        {
            _progress += Time.fixedDeltaTime / _attakDelay;
            if (_progress >= 1f)
            {
                _progress = 0f;
                _target.TakeDamage(_damege, null);
            }
        }
    }

    public void Kill()
    {
        enabled = false;
        _collider.isTrigger = true;
        _animator.SetBool("dead", true);
    }

    public void TakeDamage(int damage, Transform projectile)
    {
        _currethelth = Mathf.Clamp(_currethelth - damage, 0, _currethelth);
        if (_currethelth == 0)
            Kill();
        _decal.CreateDecal(projectile);
    }

}

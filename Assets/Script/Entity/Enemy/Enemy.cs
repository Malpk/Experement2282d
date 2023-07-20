using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private EnemyDetect _detect;
    [SerializeField] private EnemyBrain _brain;
    [SerializeField] private EnemyHealth _health;

    private float _speedMovement;

    public event System.Action<Enemy> OnDead;
    private Vector2 _surfaceNormal;

    public bool IsDead { get; private set; } = false;

    public void Reset()
    {
        IsDead = false;
        _health.Reset();
        _brain.Reset();
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void FixedUpdate()
    {
        _brain.UpdateState();
        //var x = Input.GetAxis("Horizontal");
        //var y = Input.GetAxis("Vertical");
        //Move(new Vector2(x, y));
    }
    public void Move(Vector2 move)
    {
        _rigidBody.MovePosition(_rigidBody.position +
            move * Time.fixedDeltaTime);
    }

    public void Dead()
    {
        _rigidBody.bodyType = RigidbodyType2D.Static;
        IsDead = true;
        OnDead?.Invoke(this);
    }

    public void SetTarget(Player target)
    {
        _detect.SetTarget(target);
    }

    private Vector2 GetDiraction(Vector2 direction)
    {
        if (_surfaceNormal != Vector2.zero)
        {
            var newDirection = Vector2.right * (direction.x > 0 ? 1 : -1);
            var dot = Vector2.Dot(newDirection, _surfaceNormal);
            if (dot < 0)
            {
                newDirection = dot > -0.5f ? newDirection : Vector2.up;
                newDirection -= Vector2.Dot(newDirection, _surfaceNormal) * _surfaceNormal;
                direction = newDirection;
            }
            _surfaceNormal = Vector3.zero;
        }
        return direction;
    }
}

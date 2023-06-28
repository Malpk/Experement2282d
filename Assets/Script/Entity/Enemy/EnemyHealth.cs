using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamage
{
    [SerializeField] private int _health;
    [Header("Reference")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private DecalBody _decal;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private EnemyAnimator _animator;

    private int _currethelth = 0;

    public void Reset()
    {
        _enemy.enabled = true;
        _currethelth = _health;
        _collider.isTrigger = false;
    }

    public void Kill()
    {
        _collider.isTrigger = true;
        _animator.Dead();
        _enemy.enabled = false;
    }

    public bool TakeDamage(int damage, Transform hit)
    {
        if (_currethelth > 0)
        {
            _currethelth = Mathf.Clamp(_currethelth - damage, 0, _currethelth);
            if (_currethelth == 0)
                Kill();
            _decal.CreateDecal(hit);
            return true;
        }
        else
        {
            return false;
        }
    }
}

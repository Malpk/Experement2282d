using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public event System.Action OnAttack;
    public event System.Action OnDead;

    private string _curret;

    public void Move()
    {
        PlayAnimation("move");
    }

    public void Attack()
    {
        PlayAnimation("attack");
    }

    public void Dead()
    {
        PlayAnimation("dead");
    }

    private void PlayAnimation(string next)
    {
        _animator.SetBool(next, true);
        _animator.SetBool(_curret, false);
        _curret = next;
    }

    private void AttackAnimationEvent()
    {
        OnAttack?.Invoke();
    }

    private void DeadAnimationEvent()
    {
        OnDead?.Invoke();
    }
}

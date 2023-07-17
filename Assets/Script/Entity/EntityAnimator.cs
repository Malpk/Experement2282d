using UnityEngine;
using UnityEngine.Events;

public class EntityAnimator : MonoBehaviour
{
    [SerializeField] private UnityEvent _onDead;
    [SerializeField] private Animator _animator;

    public event System.Action OnAttack;

    private string _curret;

    public void Move(bool value = true)
    {
        PlayAnimation("move", value);
    }

    public void Attack()
    {
        _animator.SetBool(_curret, false);
        _animator.SetTrigger("attack");
    }

    public void Dead(bool value = true)
    {
        PlayAnimation("dead", value);
    }

    private void PlayAnimation(string next, bool value = true)
    {
        _animator.SetBool(next, value);
        if(_curret != next)
        {
            _animator.SetBool(_curret, false);
            _curret = next;
        }
    }

    private void AttackAnimationEvent()
    {
        OnAttack?.Invoke();
    }

    private void DeadAnimationEvent()
    {
        _onDead?.Invoke();
    }
}

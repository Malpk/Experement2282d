using UnityEngine;

public class AiTarget : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private AttackPoint[] _points;

    public void Attack(int danage)
    {
        _target.TakeDamage(danage);
    }

    public bool TryGetTarget(out AttackPoint result)
    {
        result = null;
        foreach (var point in _points)
        {
            if (!point.IsBusy)
            {
                result = point;
                return true;
            }
        }
        return false;
    }
}

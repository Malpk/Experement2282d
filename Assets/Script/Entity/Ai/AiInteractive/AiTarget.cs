using UnityEngine;

public class AiTarget : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private AttackPoint[] _points;

    public void Attack(int danage)
    {
        _target.TakeDamage(danage);
    }

    public AttackPoint GetTarget(Vector2 position)
    {
        var point = _points[0];
        var distance = Vector2.Distance(_points[0].transform.position, position);
        for (int i = 1; i < _points.Length; i++)
        {
            var newDistance = Vector2.Distance(_points[i].transform.position, position);
            if (distance > newDistance)
            {
                point = _points[i];
                distance = newDistance;
            }
        }
        return point;
    }
}

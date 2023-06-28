using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyAttackStats")]
public class EnemyAttackStats : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attakDelay;
    [SerializeField] private float _attackDistance;

    public int Damage => _damage;
    public float Delay => _attakDelay;
    public float Distance => _attackDistance;
}

using UnityEngine;

[CreateAssetMenu(menuName ="Player/BodySkill")]
public class BodySkill : ScriptableObject
{
    [SerializeField] private int _health = 1;
    [SerializeField] private int _heal = 1;
    [SerializeField] private float _speedMovement = 1;
    [SerializeField] private SkillData _data;

    public int Key => _data.SkillKey;
    public int Health => _health;
    public int Heal => _heal;
    public float SpeedMovement => _speedMovement;

}

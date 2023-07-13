using UnityEngine;

public class BodySkillSet : PlayerSkills
{
    [SerializeField] private int _health = 0;
    [SerializeField] private int _heal = 0;
    [SerializeField] private float _speedMovement = 0;
    [SerializeField] private BodySkill[] _skills;

    public int Heal => _heal;
    public int Health => _health;
    public float SpeedMovement => _speedMovement;

    protected override void UpdateSkills(int key, bool mode)
    {
        if (keys.Contains(key))
        {
            var skill = GetSkill(key);
            if (mode)
            {
                _speedMovement += skill.SpeedMovement;
                _heal += skill.Heal;
                _health += skill.Health;
            }
            else
            {
                _speedMovement -= skill.SpeedMovement;
                _heal -= skill.Heal;
                _health -= skill.Health;
            }
        }
    }

    private BodySkill GetSkill(int key)
    {
        foreach (var skill in _skills)
        {
            if (skill.Key == key)
            {
                return skill;
            }
        }
        return null;
    }

}

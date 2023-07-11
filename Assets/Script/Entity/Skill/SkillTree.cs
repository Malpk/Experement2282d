using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerSkills _playerSkill;
    [SerializeField] private SkillTreeUI _skillMenu;

    private List<int> _keys = new List<int>();

    private void OnEnable()
    {
        _skillMenu.OnActivateSkill += ActivateSkill;
    }

    private void OnDisable()
    {
        _skillMenu.OnActivateSkill -= ActivateSkill;
    }

    private void ActivateSkill(SkillData data)
    {
        _keys.Add(data.SkillKey);
        _playerSkill.AddSkill(data.SkillKey);
    }
}

using UnityEngine;
using TMPro;

public class PopSkillInfo : MonoBehaviour
{
    [SerializeField] private SkillSlot _slot;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _decription;
    [SerializeField] private TextMeshProUGUI _recuridSkill;

    private Transform _parent;

    private void Awake()
    {
        _parent = transform.parent;
        SetSkill(_slot);
    }

    public void SetMode(bool mode)
    {
        gameObject.SetActive(mode);
        transform.parent = mode ? _slot.transform.parent : _parent;
    }

    private void SetSkill(SkillSlot skill)
    {
        _name.SetText(skill.Content.Name);
        _decription.SetText(skill.Content.Description);
        _recuridSkill.text = "цена активации - " + skill.Content.Price;
        if (skill.RequiredSkills != null)
        {
            foreach (var requiredSlot in skill.RequiredSkills)
            {
                _recuridSkill.text += "\nтребуется - " + requiredSlot.Name;
            }
        }
    }
}

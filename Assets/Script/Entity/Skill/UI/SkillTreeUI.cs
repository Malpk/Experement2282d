using UnityEngine;
using System.Collections.Generic;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private SkillSlot[] _slots;
    [Header("Reference")]
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private BodySkillSet _skillSet;
    [SerializeField] private UIMenu _skillMenu;
    [SerializeField] private ApplyDisplay _applyDisplay;

    private SkillSlot _selectSlot;
    private List<SkillData> _openSkill = new List<SkillData>();

    public event System.Action<SkillData> OnActivateSkill;

    public bool IsReady => _selectSlot;

    private void OnEnable()
    {
        _applyDisplay.OnApply += Activate;
        foreach (var slot in _slots)
        {
            slot.OnActivate += Choose;
        }
    }

    private void OnDisable()
    {
        _applyDisplay.OnApply += Activate;
        foreach (var slot in _slots)
        {
            slot.OnActivate += Choose;
        }
    }

    private void Start()
    {
        UpdateSlots();
    }

    public int[] Save()
    {
        var keys = new List<int>();
        foreach (var slot in _slots)
        {
            if(slot.IsActive)
                keys.Add(slot.Content.SkillKey);
        }
        return keys.ToArray();
    }

    public void Load(int[] keys)
    {
        foreach (var key in keys)
        {
            LoadSlot(key);
        }
    }

    public void Choose(SkillSlot slot)
    {
        _selectSlot = slot;
        _skillMenu.ShowSubMenu(_applyDisplay);
    }

    public void UpdateSlots()
    {
        foreach (var slot in _slots)
        {
            if (!slot.IsActive)
            {
                OpenSlot(slot);
            }
        }
    }

    private void Activate()
    {
        _selectSlot.Activate();
        _skillSet.AddSkill(_selectSlot.Content.SkillKey);
        _playerWallet.TryGiveMoney(_selectSlot.Content.Price);
        _openSkill.Add(_selectSlot.Content);
        UpdateSlots();
        OnActivateSkill?.Invoke(_selectSlot.Content);
    }

    private bool OpenSlot(SkillSlot slot)
    {
        if (_playerWallet.Money >= slot.Content.Price)
        {
            if (CheakRequiridSkills(slot.RequiredSkills))
            {
                slot.Open();
                return true;
            }
        }
        slot.Close();
        return false;
    }

    private bool CheakRequiridSkills(SkillData[] skills)
    {
        if (skills != null)
        {
            foreach (var skill in skills)
            {
                if (!_openSkill.Contains(skill))
                    return false;
            }
        }
        return true;
    }

    private void LoadSlot(int key)
    {
        foreach (var slot in _slots)
        {
            if (slot.Content.SkillKey == key)
            {
                slot.Open();
                slot.Activate();
                _openSkill.Add(slot.Content);
                _skillSet.AddSkill(slot.Content.SkillKey);
                return;
            }
        }
    }

}

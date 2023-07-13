using UnityEngine;
using System.Collections.Generic;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private SkillSlot[] _slots;
    [Header("Reference")]
    [SerializeField] private Wallet _playerWallet;
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

    public void Choose(SkillSlot slot)
    {
        _selectSlot = slot;
        _applyDisplay.Show();
    }

    private void Activate()
    {
        _selectSlot.Activate();
        _playerWallet.TryGiveMoney(_selectSlot.Content.Price);
        _openSkill.Add(_selectSlot.Content);
        UpdateSlots();
        OnActivateSkill?.Invoke(_selectSlot.Content);
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

}

using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private ApplyDisplay _applyDisplay;
    [SerializeField] private SkillSlot[] _slot;

    private SkillSlot _selectSlot;

    public event System.Action<SkillData> OnActivateSkill;

    public bool IsReady => _selectSlot;

    private void OnEnable()
    {
        _applyDisplay.OnApply += Activate;
        foreach (var slot in _slot)
        {
            slot.OnClik += Choose;
        }
    }

    private void OnDisable()
    {
        _applyDisplay.OnApply += Activate;
        foreach (var slot in _slot)
        {
            slot.OnClik -= Choose;
        }
    }

    public void Choose(SkillSlot slot)
    {
        _selectSlot = slot;
        _applyDisplay.Show();
    }

    private void Activate()
    {
        _selectSlot.Activate();
        OnActivateSkill?.Invoke(_selectSlot.Content);
    }
}

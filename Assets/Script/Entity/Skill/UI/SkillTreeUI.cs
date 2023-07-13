using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    [SerializeField] private SkillSlot[] _slots;
    [Header("Reference")]
    [SerializeField] private Wallet _playerWallet;
    [SerializeField] private ApplyDisplay _applyDisplay;

    private SkillSlot _selectSlot;

    public event System.Action<SkillData> OnActivateSkill;

    public bool IsReady => _selectSlot;

    private void OnEnable()
    {
        _applyDisplay.OnApply += Activate;
        foreach (var slot in _slots)
        {
            slot.OnChoose += Choose;
        }
    }

    private void OnDisable()
    {
        _applyDisplay.OnApply += Activate;
        foreach (var slot in _slots)
        {
            slot.OnChoose -= Choose;
        }
    }

    public void FiltrePrice()
    {
        foreach (var slot in _slots)
        {

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

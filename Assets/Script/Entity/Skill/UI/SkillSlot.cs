using UnityEngine;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] private bool _awakeOnActive;
    [SerializeField] private SkillData _content;
    [SerializeField] private SkillData[] _requredSkill;
    [Header("SelfReference")]
    [SerializeField] private SkillPoint _point;
    [SerializeField] private TreePoint _treePoint;
    [SerializeField] private TextMeshProUGUI _text;

    public event System.Action<SkillSlot> OnActivate;

    public bool IsActive { get; private set; } = false;
    public SkillData Content => _content;
    public SkillData[] RequiredSkills => _requredSkill;
 
    private void OnValidate()
    {
        _point.OnClik += ChooseSlot;
        if (_content)
        {
            _text?.SetText(_content.Name);
        }
    }

    private void OnEnable()
    {
        _point.OnClik += ChooseSlot;
    }

    private void OnDisable()
    {
        _point.OnClik -= ChooseSlot;
    }

    public void Activate()
    {
        IsActive = true;
        _point.Activate();
        _treePoint.Activate();
    }

    public void Open()
    {
        _point.SetMode(true);
    }

    public void Close()
    {
        _point.SetMode(false);
    }

    private void ChooseSlot()
    {
        OnActivate?.Invoke(this);
    }

}

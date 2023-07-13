using UnityEngine;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] private bool _awakeOnActive;
    [SerializeField] private SkillData _content;
    [Header("SelfReference")]
    [SerializeField] private SkillPoint _point;
    [SerializeField] private TreePoint _treePoint;
    [SerializeField] private TextMeshProUGUI _text;

    public event System.Action<SkillSlot> OnChoose;

    public SkillData Content => _content;

    private void Awake()
    {
        SetMode(_awakeOnActive);
    }

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
        _point.Activate();
        _treePoint.Activate();
    }

    public void SetMode(bool mode)
    {
        _point.SetMode(mode);
    }

    private void ChooseSlot()
    {
        OnChoose?.Invoke(this);
    }

}

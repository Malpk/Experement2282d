using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkillSlot : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private SkillData _content;
    [Header("Reference")]
    [SerializeField] private Image _icon;
    [SerializeField] private Animator _animator;
    [SerializeField] private TextMeshProUGUI _text;

    private bool _isActive;

    public event System.Action<SkillSlot> OnClik;

    public SkillData Content => _content;

    private void Awake()
    {
        _icon.gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        if (_content)
        {
            _text?.SetText(_content.Name);
        }
    }

    public void Activate()
    {
        _icon.gameObject.SetActive(true);
        _isActive = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetBool("select", true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isActive)
            OnClik?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetBool("select", false);
    }
}

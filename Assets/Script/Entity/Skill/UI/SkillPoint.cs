using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillPoint : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _cell;
    [SerializeField] private Animator _animator;
    [SerializeField] private PopSkillInfo _pop;

    private bool _isActive;
    private bool _mode;

    public event System.Action OnClik;

    private void Awake()
    {
        _icon.gameObject.SetActive(false);
    }

    public void SetMode(bool mode)
    {
        _mode = mode;
        _animator.SetBool("lock", !mode);
    }

    public void Activate()
    {
        _isActive = true;
        _icon.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        _icon.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pop.SetMode(true);
        if (!_isActive && _mode)
        {
            _animator.SetBool("select", true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isActive && _mode)
            OnClik?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pop.SetMode(false);
        _animator.SetBool("select", false);
    }

}

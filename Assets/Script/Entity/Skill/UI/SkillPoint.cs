using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillPoint : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _cell;
    [SerializeField] private Animator _animator;

    private bool _isActive; 

    public event System.Action OnClik;

    private void Awake()
    {
        _icon.gameObject.SetActive(false);
    }

    public void SetMode(bool mode)
    {
        _cell.raycastTarget = mode;
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
        if(!_isActive)
            _animator.SetBool("select", true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isActive)
            OnClik?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetBool("select", false);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class GunCell : MonoBehaviour
{
    [SerializeField] private Gun _containGun;
    [Header("Reference")]
    [SerializeField] private Image _gunIcon;
    [SerializeField] private Animator _animator;

    public Gun Content => _containGun;

    public bool IsSelect { get; private set; }


    public void Select()
    {
        _animator.SetBool("select", true);
        IsSelect = true;
    }

    public void Deselect()
    {
        _animator.SetBool("select", false);
        IsSelect = false;
    }

    public void SetGun(Gun gun)
    {
        _containGun = gun;
        _gunIcon.sprite = gun ? gun.Icon : null;
        _gunIcon.gameObject.SetActive(gun);
    }

    public void Replace(DataItem item)
    {
        if (item.TryGetComponent(out Gun gun))
        {
            SetGun(gun);
        }
    }
}

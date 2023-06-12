using UnityEngine;
using UnityEngine.UI;

public class GunCell : MonoBehaviour
{
    [SerializeField] private Gun _containGun;
    [Header("Reference")]
    [SerializeField] private Image _gunIcon;
    [SerializeField] private Animator _animator;


    public Gun Content => _containGun;

    public void Select()
    {
        _animator.SetBool("select", true);
    }

    public void Deselect()
    {
        _animator.SetBool("select", false);
    }

    public void SetGun(Gun gun)
    {
        _containGun = gun;
        _gunIcon.sprite = gun.Icon;
    }

}

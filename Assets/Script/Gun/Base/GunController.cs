using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GunMenu _gunMenu;
    [Header("Hand")]
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;
    [Header("Reference")]
    [SerializeField] private Gun _gun;
    [SerializeField] private GunDirection _holderDirection;

    private bool IsBkock => _gunMenu ? _gunMenu.IsShow : false;

    public event System.Action<Gun> OnSetGun;

    public void TakeGun(Gun gun)
    {
        if (_gun)
            _gun.gameObject.SetActive(false);
        gun.gameObject.SetActive(true);
        GrabGun(gun);
        _gun = gun;
        OnSetGun?.Invoke(gun);
        gun.UpdateGun();
        _holderDirection.SetGun(gun);
    }

    public bool Shoot(bool input)
    {
        if (!IsBkock)
        {
            return _gun.Shoot(input);
        }
        return false;
    }

    public void Reload(bool input)
    {
        if(!IsBkock)
            _gun.Reload(input);
    }

    public void DropGun()
    {
        _gun.gameObject.SetActive(false);
        _gun = null;
        _rightHand.parent = transform;
        _leftHand.parent = transform;
    }

    private void GrabGun(Gun gun)
    {
        _rightHand.parent = gun.RightHandPoint;
        _leftHand.parent = gun.LeftHandPoint;
        _rightHand.localPosition = Vector3.zero;
        _leftHand.localPosition = Vector3.zero;
    }

}

using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [Header("Hand")]
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;
    [Header("GunSetting")]
    [SerializeField] private Gun _gun;
    [SerializeField] private Gun[] _guns;
    [Header("Reference")]
    [SerializeField] private UIMenu _gunMenu;
    [SerializeField] private GunHolderDirection _holderDirection;

    public event System.Action<Gun> OnSetGun;

    public Gun[] Guns => _guns;

    public void Reset()
    {
        foreach (var gun in _guns)
        {
            if(gun)
                gun.Reset();
        }
    }

    private void Start()
    {
        SetGun(_gun);
    }

    public void SetGun(Gun gun)
    {
        if (_gun)
            _gun.gameObject.SetActive(false);
        gun.gameObject.SetActive(true);
        GrabGun(gun);
        _gun = gun;
        OnSetGun?.Invoke(_gun);
        _holderDirection.SetGun(gun);
    }

    public void SwitchGunMenu(bool input)
    {
        if (input)
            _gunMenu.SwitchState();
    }

    public bool Shoot(bool input)
    {
        if (!_gunMenu.IsShow)
        {
            return _gun.Shoot(input);
        }
        return false;
    }

    public void Reload(bool input)
    {
        if(!_gunMenu.IsShow)
            _gun.Reload(input);
    }

    private void GrabGun(Gun gun)
    {
        _rightHand.parent = gun.RightHandPoint;
        _leftHand.parent = gun.LeftHandPoint;
        _rightHand.localPosition = Vector3.zero;
        _leftHand.localPosition = Vector3.zero;
    }

}

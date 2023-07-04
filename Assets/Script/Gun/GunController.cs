using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Hand")]
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;
    [Header("Reference")]
    [SerializeField] private Gun _gun;
    [SerializeField] private GunDirection _holderDirection;

    private bool _isBlock;

    public event System.Action<Gun> OnSetGun;

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

    public bool Shoot(bool input)
    {
        input = input && !_isBlock;
        return _gun.Shoot(input);
    }

    public void Reload(bool input)
    {
        input = input && !_isBlock;
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

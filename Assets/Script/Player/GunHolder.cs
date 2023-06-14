using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.IK;

public class GunHolder : MonoBehaviour
{
    [Header("Hand")]
    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;
    [Header("GunSetting")]
    [SerializeField] private Gun _gun;
    [SerializeField] private Gun[] _guns;
    [Header("Reference")]
    [SerializeField] private GunInfo _uiInfo;
    [SerializeField] private UIMenu _gunMenu;

    public Gun[] Guns => _guns;
    private void Start()
    {
        SetGun(_gun);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _gunMenu.SwitchState();
        }
    }

    public void SetGun(Gun gun)
    {
        if (_gun)
        {
            _gun.OnReload -= UpdateGunInfo;
            _gun.gameObject.SetActive(false);
        }
        gun.OnReload += UpdateGunInfo;
        gun.gameObject.SetActive(true);
        GrabGun(gun);
        _gun = gun;
        _uiInfo.SetIcon(gun.Icon);
        UpdateGunInfo();
    }

    private void GrabGun(Gun gun)
    {
        _rightHand.parent = gun.RightHandPoint;
        _leftHand.parent = gun.LeftHandPoint;
        _rightHand.localPosition = Vector3.zero;
        _leftHand.localPosition = Vector3.zero;
    }

    public void Shoot()
    {
        if (!_gunMenu.IsShow)
        {
            if (_gun.Shoot())
                UpdateGunInfo();
        }
    }

    public void Reload()
    {
        if(!_gunMenu.IsShow)
            _gun.Reload();
    }

    public void SetDirectionShoot(Vector2 mousePosition)
    {
        transform.right = mousePosition;
        _gun.transform.right = mousePosition;
        Flip(mousePosition);
        Debug.DrawLine(transform.position, transform.position + transform.right * 20, Color.red);
        Debug.DrawLine(transform.position, transform.position + _gun.transform.right * 20, Color.green);
    }

    private void Flip(Vector2 direction)
    {
        var flip = direction.x > 0 ? 1 : -1;
        var y = Mathf.Abs(_gun.transform.localScale.y) * flip;
        _gun.transform.localScale = new Vector3(_gun.transform.localScale.x, y, _gun.transform.localScale.z);
    }


    private void UpdateGunInfo()
    {
        _uiInfo.UpdateText(_gun.CurrteMagazine, _gun.CurretAmmo);
    }

}

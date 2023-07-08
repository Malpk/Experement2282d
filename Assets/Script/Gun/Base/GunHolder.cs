using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [Header("GunSetting")]
    [SerializeField] private GunSlot[] _slots;
    [Header("Reference")]
    [SerializeField] private GunMenu _gunMenu;
    [SerializeField] private Transform _gunHolder;
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private GunController _controller;

    private Gun _chooseGun;

    public GunSlot[] Slots => _slots;

    public void Reset()
    {
        foreach (var slot in _slots)
        {
            if (slot.Gun)
                slot.Gun.Reset();
        }
    }

    private void Awake()
    {
        SetGun(_slots[0].Gun);
        foreach (var slot in _slots)
        {
            slot.Intilizate(_gunHolder);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ammo ammo))
        {
            AddAmmo(ammo);
        }
    }

    public string Save()
    {
        var data = new GunHolderData();
        data.ContainGuns = new int[_slots.Length];
        data.ChooseGun = GetChooseSlot(_chooseGun);
        for (int i = 0; i < _slots.Length; i++)
        {
            data.ContainGuns[i] = _slots[i].Gun ? _slots[i].Gun.ID : -1;
        }
        return JsonUtility.ToJson(data);
    }

    public void Load(Gun[] guns, int selectGun)
    {
        _controller.DropGun();
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].SetGun(guns[i]);
        }
        SetGun(_slots[selectGun].Gun);
    }

    public void SetGun(Gun gun)
    {
        _chooseGun = gun;
        _controller.TakeGun(gun);
    }

    public bool IsContain(int id)
    {
        foreach (var slot in _slots)
        {
            if (slot.Gun)
            {
                if (slot.Gun.ID == id)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void SwitchGunMenu(bool input)
    {
        if (input)
            _gunMenu.SwitchState();
    }

    private int GetChooseSlot(Gun gun)
    {
        for (int i = 0; i < _slots.Length && gun; i++)
        {
            if (_slots[i].Gun == gun)
            {
                return i;
            }
        }
        return 0;
    }

    private void AddAmmo(Ammo ammo)
    {
        if (TryGetGun(ammo.Gun, out Gun gun))
        {
            if (gun.AddAmmo(ammo.CountAmmo))
            {
                _sound.Pick();
                ammo.Delete();
            }
        }
    }

    private bool TryGetGun(GunType type,out Gun gun)
    {
        gun = null;
        foreach (var slot in _slots)
        {
            if (slot.Gun)
            {
                if (slot.Gun.GunType == type)
                {
                    gun = slot.Gun;
                    return true;
                }
            }
        }
        return false;
    }

}

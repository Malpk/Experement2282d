public class ReplaceCell : CellUI
{
    private GunSlot _slot;

    private void OnEnable()
    {
        OnUpdateContent += _slot.SetGun;
    }

    private void OnDisable()
    {
        OnUpdateContent -= _slot.SetGun;
    }

    public void SetGunSlot(GunSlot slot)
    {
        if (_slot!= null)
            OnUpdateContent -= _slot.SetGun;
        _slot = slot;
        if(enabled)
            OnUpdateContent += _slot.SetGun;
    }
}

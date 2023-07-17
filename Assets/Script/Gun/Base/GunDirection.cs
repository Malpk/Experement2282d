using UnityEngine;

public class GunDirection : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    public void SetGun(Gun gun)
    {
        _gun = gun;
    }

    public void SetDirectionShoot(Vector3 mousePosition)
    {
        transform.right = mousePosition;
        Flip(mousePosition);
    }

    private void Flip(Vector2 direction)
    {
        var flip = direction.x > 0 ? 1 : -1;
        var y = Mathf.Abs(_gun.transform.localScale.y) * flip;
        _gun.transform.localScale = new Vector3(_gun.transform.localScale.x, y, _gun.transform.localScale.z);
    }
}

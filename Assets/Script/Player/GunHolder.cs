using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    public void Shoot()
    {
        _gun.Shoot();
    }

    public void Reload()
    {
        _gun.Relaod();
    }

    public void SetDirectionShoot(Vector2 mousePosition)
    {
        transform.right = mousePosition;
        Flip(transform.right);
    }

    private void Flip(Vector2 direction)
    {
        var flip = direction.x > 0 ? 1 : -1;
        var y = Mathf.Abs(_gun.transform.localScale.y) * flip;
        _gun.transform.localScale = new Vector3(_gun.transform.localScale.x, y, _gun.transform.localScale.z);
    }
}

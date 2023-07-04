using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private GunDirection _gunHolder;

    private void Update()
    {
        Vector2 direction = Input.mousePosition - _mainCamera.WorldToScreenPoint(transform.position);
        FlipBody(direction.x);
        _gunHolder.SetDirectionShoot(direction);
    }

    private void FlipBody(float direction)
    {
        if (direction != 0)
        {
            var x = Mathf.Abs(_playerBody.localScale.x) * (direction > 0 ? 1 : -1);
            _playerBody.localScale = new Vector3(x, _playerBody.localScale.y, _playerBody.localScale.z);
        }
    }
}

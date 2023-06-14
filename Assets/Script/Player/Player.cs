using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _hudCamera;
    [SerializeField] private GunHolder _gunHolder;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _target;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerSound _sound;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        _target.position = (Vector2)_hudCamera.ScreenToWorldPoint(Input.mousePosition);
        var localPosition = _target.position - _gunHolder.transform.position;
        FlipBody(localPosition.x);
        _gunHolder.SetDirectionShoot(localPosition);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _gunHolder.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _gunHolder.Reload();
        }
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        _movement.Move(x, y);
        if (x != 0 || y != 0)
            _sound.Steap();
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

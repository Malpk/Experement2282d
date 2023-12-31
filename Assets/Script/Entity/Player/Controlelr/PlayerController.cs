using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GunController _gun;
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerMovement _movement;

    private void Update()
    {
        _gun.Reload(Input.GetKeyDown(KeyCode.R));
        _gun.Shoot(Input.GetKey(KeyCode.Mouse0));
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Move(new Vector2(x, y));
    }

    public void Move(Vector2 input)
    {
        _movement.Move(input.x, input.y);
        if (input != Vector2.zero)
            _sound.Steap();
    }

}

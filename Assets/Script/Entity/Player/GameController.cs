using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GunHolder _holder;
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerMovement _movement;

    private void Update()
    {
        _holder.Reload(Input.GetKeyDown(KeyCode.R));
        _holder.Shoot(Input.GetKey(KeyCode.Mouse0));
        _holder.SwitchGunMenu(Input.GetKeyDown(KeyCode.E));
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

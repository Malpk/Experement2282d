using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GunHolder _holder;
    [SerializeField] private GunController _gun;
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private UIMenu _skillMenu;

    private bool _block;

    private System.Action<bool> _interactive;

    private void Start()
    {
        _interactive = ShowGunMenu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            _skillMenu.SwitchState();
        if (!_skillMenu.IsShow)
        {
            if (!_block)
            {
                _gun.Reload(Input.GetKeyDown(KeyCode.R));
                _gun.Shoot(Input.GetKey(KeyCode.Mouse0));
            }
            _interactive.Invoke(Input.GetKeyDown(KeyCode.E));
        }
    }

    private void FixedUpdate()
    {
        if (!_block && !_skillMenu.IsShow)
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            Move(new Vector2(x, y));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractive interactive))
        {
            _interactive = (bool input) =>
            {
                interactive.Interactive(input);
                _block = interactive.IsBlock;
            };
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractive interactive))
        {
            _interactive = ShowGunMenu;
        }
    }

    public void ShowGunMenu(bool input)
    {
        _holder.SwitchGunMenu(input);
    }

    public void Move(Vector2 input)
    {
        _movement.Move(input.x, input.y);
        if (input != Vector2.zero)
            _sound.Steap();
    }

}

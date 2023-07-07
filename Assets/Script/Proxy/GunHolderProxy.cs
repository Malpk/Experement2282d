using UnityEngine;

namespace Proxy
{
    public class GunHolderProxy : MonoBehaviour
    {
        [SerializeField] private GunSlot[] _slots;
        [SerializeField] private GunMenu _gunMenu;
        [SerializeField] private ReplaceGunMenu _replaceMenu;

        private void Awake()
        {
            foreach (var slot in _slots)
            {
                slot.Intilizate(transform);
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _gunMenu.SwitchState();
            }
        }

        public void RemoveGun(Gun gun)
        {
            _gunMenu.RemoveGun(gun);
        }

    }
}
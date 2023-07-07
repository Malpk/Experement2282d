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
            _replaceMenu.Intilizate(_slots);
            foreach (var slot in _slots)
            {
                if(slot.Gun)
                    slot.Intilizate();
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
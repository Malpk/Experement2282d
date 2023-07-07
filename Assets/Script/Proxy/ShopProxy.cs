using UnityEngine;

namespace Proxy
{
    public class ShopProxy : MonoBehaviour
    {
        [SerializeField] private DataItem _goods;
        [SerializeField] private ReplaceGunMenu _replace;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _replace.IsShow)
            {
                _replace.SwitchState();
            }
        }

        public void AddGun()
        {
            _replace.SetReplce(_goods);
            _replace.Show();
        }

    }
}

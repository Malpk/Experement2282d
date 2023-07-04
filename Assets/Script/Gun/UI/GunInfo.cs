using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunInfo : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;
    [Header("SceneReference")]
    [SerializeField] private GunController _gun;

    private Gun _curretGun;

    private void OnEnable()
    {
        _gun.OnSetGun += SetGun;
    }

    private void OnDisable()
    {
        _gun.OnSetGun -= SetGun;
    }

    private void SetGun(Gun gun)
    {
        if (_curretGun)
        {
            _curretGun.OnUpdateMagazine -= UpdateText;
        }
        _curretGun = gun;
        _image.sprite = gun.Icon;
        _curretGun.OnUpdateMagazine += UpdateText;
    }

    private void UpdateText(int magazine, int ammo)
    {
        _text.text = magazine.ToString() + "/" + ammo.ToString();
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunInfo : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetIcon(Sprite icon)
    {
        _image.sprite = icon;
    }

    public void UpdateText(int magazine, int ammo)
    {
        _text.text = magazine.ToString() + "/" + ammo.ToString();
    }
}

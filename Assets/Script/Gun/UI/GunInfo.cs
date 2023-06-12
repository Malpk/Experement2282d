using UnityEngine;
using TMPro;

public class GunInfo : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(int magazine, int ammo)
    {
        _text.text = magazine.ToString() + "/" + ammo.ToString();
    }
}

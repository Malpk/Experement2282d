using UnityEngine;
using TMPro;

public class TextPrefix : MonoBehaviour
{
    [SerializeField] private string _prefix;
    [Header("Reference")]
    [SerializeField] private TextMeshProUGUI _price;

    public void SetText(string text)
    {
        _price.text = _prefix + text;
    }
}

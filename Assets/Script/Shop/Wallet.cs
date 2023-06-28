using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnValidate()
    {
        if (_text)
            _text.text = _money.ToString();
    }

    public void TakeMoney(int money)
    {
        _money += money;
        UpdateUI();
    }

    public bool TryGiveMoney(int money)
    {
        if (_money >= money)
        {
            _money -= money;
            UpdateUI();
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        _text.text = _money.ToString();
    }
}

using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TextNumUI _text;

    private void OnValidate()
    {
        if (_text)
            _text.SetValue(_money);
    }

    public void SetRegress(float regress)
    {
        _money = (int)(_money / regress);
        _text.SetValue(_money);
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
            _text.SetValue(_money);
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        _text.UpdateText(_money);
    }
}

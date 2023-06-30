using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;
    [Header("Event")]
    [SerializeField] private UnityEvent<int> _onChangeMoney;
    [SerializeField] private UnityEvent<int> _onSetMoney;

    private void OnValidate()
    {
        _onChangeMoney.Invoke(_money);
    }

    public void SetRegress(float regress)
    {
        _money = (int)(_money / regress);
        _onSetMoney.Invoke(_money);
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
            _onSetMoney.Invoke(_money);
            return true;
        }
        return false;
    }

    private void UpdateUI()
    {
        _onChangeMoney.Invoke(_money);
    }
}

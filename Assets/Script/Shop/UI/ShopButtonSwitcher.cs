using UnityEngine;
using UnityEngine.UI;

public class ShopButtonSwitcher : MonoBehaviour
{
    [SerializeField] private Button _buy;
    [SerializeField] private Button _choose;
    [SerializeField] private GameObject _activeChoose;

    private GameObject _curretActive;

    public void ShowBuyButton()
    {
        Show(_buy.gameObject);
    }

    public void ShowChooseButton()
    {
        Show(_choose.gameObject);
    }

    public void ShowPutTable()
    {
        Show(_activeChoose);
    }

    private void Show(GameObject button)
    {
        if (_curretActive != button)
        {
            if (_curretActive)
                _curretActive.SetActive(false);
            button.SetActive(true);
            _curretActive = button;
        }
    }
}

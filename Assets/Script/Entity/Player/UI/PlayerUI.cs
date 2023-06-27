using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Color _fullHealth;
    [SerializeField] private Color _deadColor;
    [Header("Reference")]
    [SerializeField] private Player _player;
    [Header("UIReference")]
    [SerializeField] private Image _healthField;

    private void OnEnable()
    {
        _player.OnChageHealth += UpdateHealth;
    }

    private void OnDisable()
    {
        _player.OnChageHealth -= UpdateHealth;
    }

    private void UpdateHealth(float progerss)
    {
        _healthField.fillAmount = progerss;
        _healthField.color = Color.Lerp(_deadColor, _fullHealth, progerss);
    }
}

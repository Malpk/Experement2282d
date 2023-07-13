using UnityEngine;
using UnityEngine.UI;

public class Edge : MonoBehaviour
{
    [SerializeField] private Image _field;

    public void SetMode(bool mode)
    {
        _field.fillAmount = mode ? 1f : 0f;
    }

}

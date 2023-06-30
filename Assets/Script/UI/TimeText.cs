using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _minute = 60;

    public void SetTime(int second)
    {
        _text.text = $"{Formatet(second / _minute)}:" +
            $"{Formatet(second % _minute)}";
    }

    private string Formatet(int num)
    {
        var numStr = num.ToString();
        while (numStr.Length < 2)
        {
            numStr = "0" + numStr;
        }
        return numStr;
    }
}

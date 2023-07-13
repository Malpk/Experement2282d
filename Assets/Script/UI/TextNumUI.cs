using System.Collections;
using UnityEngine;
using TMPro;

public class TextNumUI : MonoBehaviour
{
    [SerializeField] private float _moveDelte;
    [Header("SelfReference")]
    [SerializeField] private TextMeshProUGUI _text;

    private float _curretValue = 0;

    private Coroutine _corotine;

    public void SetValue(int value)
    {
        if (_corotine != null)
            StopCoroutine(_corotine);
        _curretValue = value;
        SetText(_curretValue);
    }

    public void UpdateText(int target)
    {
        if (_corotine != null)
            StopCoroutine(_corotine);
        _corotine =StartCoroutine(TextAnimation(target));
    }

    private IEnumerator TextAnimation(int target)
    {
        while (_curretValue!= target)
        {
            _curretValue = Mathf.MoveTowards(_curretValue, target, _moveDelte);
            SetText(_curretValue);
            yield return null;
        }
        _corotine = null;
    }

    private void SetText(float value)
    {
        value = (int)value;
        _text.text = value.ToString();
    }
}

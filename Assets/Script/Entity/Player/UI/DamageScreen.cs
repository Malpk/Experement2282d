using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Color _colorHit;
    [SerializeField] private Image _screen;

    private Color _baseColor;
    private Coroutine _corotine;

    private void Awake()
    {
        _baseColor = _screen.color;
    }

    public void Hit()
    {
        if (_corotine != null)
            StopCoroutine(_corotine);
        _corotine = StartCoroutine(HitAnimation());
    }

    private IEnumerator HitAnimation()
    {
        _screen.DOColor(_colorHit, _duration);
        yield return new WaitForSeconds(_duration);
        _screen.DOColor(_baseColor, _duration);
    }
}

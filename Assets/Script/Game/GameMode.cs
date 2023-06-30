using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameMode : MonoBehaviour
{
    [SerializeField] private float _timeActive;
    [SerializeField] private float _safeTime;
    [Header("Event")]
    [SerializeField] private UnityEvent<int> _onTimeUpdate;
    [Header("Reference")]
    [SerializeField] private KillReward _reward;
    [SerializeField] private EnemySpawner _sapwner;

    private Coroutine _corotine;

    public bool IsActive { get; private set; } = false;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        if (_corotine == null)
            _corotine = StartCoroutine(ModeUpdate());
    }

    public void Stop()
    {
        IsActive = false;
        _corotine = null;
        StopAllCoroutines();
    }

    private IEnumerator ModeUpdate()
    {
        while (enabled)
        {
            IsActive = true;
            _sapwner.Play();
            yield return WaitTime(_timeActive);
            IsActive = false;
            _sapwner.Stop();
            yield return new WaitWhile(() => _reward.CountEnemy > 0);
            yield return WaitTime(_safeTime);
        }
    }

    private IEnumerator WaitTime(float time)
    {
        var progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime / time;
            _onTimeUpdate.Invoke((int)(time - time * progress));
            yield return null;
        }
    }
}

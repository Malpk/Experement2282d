using System.Collections;
using UnityEngine;

public class Decal : MonoBehaviour
{
    [SerializeField] private float _timeDelete;
    [Header("Reference")]
    [SerializeField] private PoolItem _decal;
    [SerializeField] private ParticleSystem _partical;

    private void OnEnable()
    {
        _partical.Play();
        StartCoroutine(Delete());
    }

    private void OnDisable()
    {
        _partical.Stop();
        StopAllCoroutines();
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(_timeDelete);
        _decal.Delete();
    }

}

using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _steap;
    [Header("Reference")]
    [SerializeField] private AudioSource _source;

    private Coroutine _coroutine;

    public void Steap()
    {
        if(_coroutine == null) 
        {
            _source.PlayOneShot(_steap);
            _coroutine = StartCoroutine(WaitCompliteSteap());
        }
    }
    
    private IEnumerator WaitCompliteSteap()
    {
        yield return new WaitForSeconds(_steap.length / 2);
        _coroutine = null;
    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Timed_UnityEvent : MonoBehaviour
{
    public float Duration = 1f;
    public bool StartOnEnable = false;
    public UnityEvent TimerEvent;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        if (StartOnEnable)
        {
            StartTimer();
        }
    }

    private void OnDisable()
    {
        StopTimer();
    }

    public void StartTimer()
    {
        if(_coroutine != null) StopTimer();
        Debug.Log("Starting Timer");
        _coroutine = StartCoroutine(CoEventTimer(Duration));
    }

    public void StopTimer()
    {
        if (_coroutine != null)
        {
            Debug.Log("Stopping Timer");
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CoEventTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        TimerEvent.Invoke();
        _coroutine = null;
    }
}

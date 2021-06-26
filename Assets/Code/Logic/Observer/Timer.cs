using System.Collections;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Action OnTimerStarted;
    public Action OnTimerIsCritical;
    public Action OnTimerEnded;

    private IEnumerator TimeCorroutine;

    public void StartTimer()
    {
        TimeCorroutine = RunTime();
    }

    private IEnumerator RunTime()
    {
        if(OnTimerStarted != null)
            OnTimerIsCritical();

        if(OnTimerIsCritical != null)
            OnTimerIsCritical();

        if(OnTimerEnded != null)
            OnTimerEnded();

        TimeCorroutine = null;
        yield break;
    }

}

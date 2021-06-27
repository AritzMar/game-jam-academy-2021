using System.Collections;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static Action OnTimerStarted;
    public static Action OnTimerIsCritical;
    public static Action OnTimerEnded;

    [SerializeField] private StateListener stateListener;

    [SerializeField] private IntVariable timeToDo;

    private IEnumerator TimeCorroutine;

    public void StartTimer()
    {
        TimeCorroutine = RunTime();
        StartCoroutine(TimeCorroutine);
    }

    public void StopTimer()
    {
        StartCoroutine(TimeCorroutine);
        timeToDo.ResetCurrentToInitial();
    }

    private IEnumerator RunTime()
    {
        float reducedTime = timeToDo.CurrentValue / 2f;

        if(OnTimerStarted != null)
            OnTimerStarted();

        yield return new WaitForSeconds(reducedTime);

        if(OnTimerIsCritical != null)
            OnTimerIsCritical();

        while(reducedTime >= float.Epsilon)
        {
            reducedTime -= Time.deltaTime;
            yield return null;
        }

        if(OnTimerEnded != null)
            OnTimerEnded();

        TimeCorroutine = null;
        yield break;
    }

}

using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private IntVariable timeToDo;
	[SerializeField] private FlowHandler flowHandler;

	private IEnumerator TimeCorroutine;

	private bool timerRunning = false;
	public void ChangeTimerRunning(bool condition) => timerRunning = condition; 

	public void StartTimer()
	{
		timerRunning = true;

		TimeCorroutine = RunTime();
		StartCoroutine(TimeCorroutine);
	}

	public void StopTimer()
	{
		StopCoroutine(TimeCorroutine);
		timeToDo.ResetCurrentToInitial();
	}

	private IEnumerator RunTime()
	{
		if (!timerRunning)
			yield break;

		while(timeToDo.CurrentValue > uint.MinValue)
		{
			timeToDo.CurrentValue -= 1;
			yield return new WaitForSeconds(1f);
		} 

		flowHandler.PerformAModifier();

		timerRunning = false;
	}
}

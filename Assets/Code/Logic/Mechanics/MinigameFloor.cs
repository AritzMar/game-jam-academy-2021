using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinigameFloor : MonoBehaviour
{
	public static Action<Transform> OnPinPositionIsPlaying;
	public static Action OnPinPositionIdle;

	[SerializeField] private Pin pinTarget;
	[SerializeField] private float checkingSpeed;
	[SerializeField] private float checkingDistance;
	private IEnumerator checkingCorroutine;

	public void DoChecking() 
	{
		checkingCorroutine = CheckLastPosition();
		StartCoroutine(checkingCorroutine);
	}

	public void NotDoChecking()
	{
		if (checkingCorroutine != null)
			StopCoroutine(checkingCorroutine);
	}

	public IEnumerator CheckLastPosition()
	{
		if(OnPinPositionIsPlaying != null)
			OnPinPositionIsPlaying(pinTarget.transform);

		while(true)
		{
			List<Vector3> points = new List<Vector3>();
			float elapsed_time = 0;

			while (elapsed_time < checkingSpeed)
			{
				points.Add(pinTarget.CloneLocation().position);

				yield return new WaitForSeconds(checkingSpeed/10);

				elapsed_time += checkingSpeed / 10;
			}

			if(ComputeTotalDistance(points) <= checkingDistance)
			{
				if(OnPinPositionIdle != null)
					OnPinPositionIdle?.Invoke();
			}
		}
	}

	private float ComputeTotalDistance(List<Vector3> points)
	{
		int last = points.Count - 1;
		float total_distance = 0;

		for (int i = 0; i < last; i++)
			total_distance += Vector3.Distance(points[i], points[i + 1]);

		return total_distance;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicFadeAndDestroy : MonoBehaviour
{
	public float transitionTime;
	public AudioMixerSnapshot musicMute;
	public AudioMixerSnapshot musicUp;

	public void TransitionToGame()
	{
		musicMute.TransitionTo(transitionTime);
		StartCoroutine(WaitAndDestroy(transitionTime));
	}
	IEnumerator WaitAndDestroy(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		GameObject[] activeMusicContainers = GameObject.FindGameObjectsWithTag("MusicContainer");
		foreach (GameObject go in activeMusicContainers)
		{
			Destroy(go);
		}
		musicUp.TransitionTo(transitionTime);
	}
}

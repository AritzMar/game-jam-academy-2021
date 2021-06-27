using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSounds : MonoBehaviour
{
	public AudioClip[] randomClips;
	public AudioSource randomClipSource;
	private float waitTime = 2;
	private float counter;
	private int index = 0;
	private void Update()
	{
		counter += Time.deltaTime;
		if(counter >= waitTime)
		{
			randomClipSource.clip = randomClips[index];
			randomClipSource.Play();
			index++;
			counter = 0;
			index = Random.Range(0, randomClips.Length - 1 );
			waitTime = Random.Range(2, 8);
		}
	}
}

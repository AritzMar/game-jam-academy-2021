using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSounds : MonoBehaviour
{
	[Header("---START---")]
	public bool playOnStartRandomSound;
	public float delay;
	public AudioSource voiceSource;
	public AudioClip[] randomClipsStart;

	[Header("---RANDOM---")]
	public AudioClip[] randomClips;
	public AudioSource randomClipSource;
	private float waitTime = 2;
	private float counter;
	private int index = 0;
	private void Start()
	{
		if (playOnStartRandomSound)
		{
			StartCoroutine(WaitStartSound(delay));
		}
	}
	IEnumerator WaitStartSound(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		voiceSource.PlayOneShot(randomClipsStart[Random.Range(0, randomClipsStart.Length - 1)]);
	}

	private void Update()
	{
		counter += Time.deltaTime;
		if(counter >= waitTime)
		{
			randomClipSource.panStereo = Random.Range(-0.5f , 0.5f);
			randomClipSource.clip = randomClips[index];
			randomClipSource.Play();
			index++;
			counter = 0;
			index = Random.Range(0, randomClips.Length - 1 );
			waitTime = Random.Range(2, 8);
		}
	}
}

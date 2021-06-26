using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundResources : MonoBehaviour
{
	private static AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	public static void PlaySound_String(string name)
	{
		AudioClip audio = Resources.Load<AudioClip>("Audio/" + name) as AudioClip;
		source.PlayOneShot(audio);
	}
}

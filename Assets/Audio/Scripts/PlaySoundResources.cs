using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundResources : MonoBehaviour
{
	public UnityEngine.Audio.AudioMixerGroup mixerOuput;
	private static AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
		source.outputAudioMixerGroup = mixerOuput;
	}
	public static void PlaySound_String(string name)
	{
		AudioClip audio = Resources.Load<AudioClip>("Audio/GJA_SFX_Assets/" + name ) ;
		source.PlayOneShot(audio);
	}
	public static void ChangePitch(float newPitch)
	{
		source.pitch = newPitch;
	}
}

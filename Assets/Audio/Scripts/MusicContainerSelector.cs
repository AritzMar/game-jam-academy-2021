using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MusicContainerSelector : MonoBehaviour
{
	private MusicContainerSelector instance;
	public static MusicContainerSelector Instance;

	public AudioMixer musicMixer;
	[Header("---CONTAINERS---")]
	public MusicContainer introContainer;
	public MusicContainer gameContainer;
	public MusicContainer minigameContainer;

	[Header("---SNAPSHOTS---")]
	public  AudioMixerSnapshot melodyOn;
	public  AudioMixerSnapshot melodyOff;
	public  AudioMixerSnapshot percFinalOn;

	[Header("---TRANSITION TIME---")]
	/*
	public float melodyOnTransition;
	public float melodyOffTransition; 
	public float percFinalTransition; */
	public float transitionTime;
	private void Awake()
	{
		instance = new MusicContainerSelector();
		Instance = instance;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	public void ChangeSnapshot(string snapshot)
	{
		switch (snapshot)
		{
			case "melodyOn":
				melodyOn.TransitionTo(transitionTime);
				break;
			case "melodyOff":
				melodyOff.TransitionTo(transitionTime);
				break;
			case "PercFinalOn":
				percFinalOn.TransitionTo(transitionTime);
				break;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundTorreta : MonoBehaviour
{
	public AudioSource turret;
    public float duration;

	public void LaserVolumeUp()
	{
            float currentTime = 0;
            float start = turret.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                turret.volume = Mathf.Lerp(start, 1 , currentTime / duration);
            }
    }
    public void LaserVolumeDown()
	{
        float currentTime = 0;

        float start = turret.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            turret.volume = Mathf.Lerp(start, 0, currentTime / duration);
        }
    }
	
}

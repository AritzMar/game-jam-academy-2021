using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonHighlightSound : MonoBehaviour , IPointerEnterHandler
{
	public string nameOfSound;
	public void OnPointerEnter(PointerEventData eventData)
	{
		PlaySoundResources.PlaySound_String(nameOfSound);
	}
}

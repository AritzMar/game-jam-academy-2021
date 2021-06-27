using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCardEffectOnCollide : MonoBehaviour
{
	[SerializeField] private SelectedCardScriptable selectedCard;

	private void OnTriggerEnter(Collider other)
	{
		if(selectedCard.SelectedCard != null)
		{
			selectedCard.SelectedCard.Effect();
			selectedCard.SelectedCard = null;
		}
	}
}

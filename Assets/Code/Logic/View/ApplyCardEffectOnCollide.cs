using UnityEngine.Events;
using UnityEngine;

public class ApplyCardEffectOnCollide : MonoBehaviour
{
	[SerializeField] private SelectedCardScriptable selectedCard;
	[SerializeField] private UnityEvent onEnteredWithCard;

	private void OnTriggerEnter(Collider other)
	{
		if(selectedCard.SelectedCard != null)
		{
			selectedCard.SelectedCard.Effect();
			selectedCard.SelectedCard = null;
			onEnteredWithCard?.Invoke();
		}
	}
}

using UnityEngine;
using Chtulhitos.Mechanics;

public class ShuffleButton : MonoBehaviour
{
	public DeckController deckController;
	public SelectedCardScriptable selectedCard;
	public MeshRenderer myRend;
	public Color activeColor;
	public Color inactiveColor;
	private bool active;

	private void OnTriggerEnter(Collider other)
	{
		if (!active)
		{
			selectedCard = null;
			other.GetComponent<Movement>().DeactivateHeadGO();
			deckController.GetCards();
			SetActive(true);
		}
	}

	public void SetActive(bool status)
	{
		active = status;
		if (!status)
			myRend.material.color = inactiveColor;
		else
			myRend.material.color = activeColor;
	}
}
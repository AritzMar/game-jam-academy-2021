using UnityEngine;
using System.Collections;
using Chtulhitos.Mechanics;
using TMPro;

public class ShuffleButton : MonoBehaviour
{
	public DeckController deckController;
	public SelectedCardScriptable selectedCard;
	public MeshRenderer myRend;
	public Color activeColor;
	public Color inactiveColor;
	public TextMeshPro shuffleText;
	public int coolDown;

	private bool active;

	private void OnTriggerEnter(Collider other)
	{
		if (!active)
		{
			selectedCard = null;
			other.GetComponent<Movement>().DeactivateHeadGO();
			deckController.GetCards();
			SetActive(true);
			StartCoroutine(ReactivateButton());
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

	private IEnumerator ReactivateButton()
	{
		int count = coolDown;
		while(count > 0)
		{
			count -= 1;
			shuffleText.text = count.ToString();
			yield return new WaitForSeconds(1);
		}
		shuffleText.text = "Shuffle";
		SetActive(false);
	}
}
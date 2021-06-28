using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private DeckScriptable deck;
	[SerializeField] private DeckScriptable visibleCards;
	[SerializeField] private SelectedCardScriptable selectedCard;

	public System.Action OnFirstCardChange;
	public System.Action OnSecondCardChange;
	public System.Action OnThirdCardChange;

	private void Start()
	{
		Shuffle();
	}

	public void Shuffle() => deck.Shuffle();
	public void GetCards()
	{
		for (int i = 0; i < 3; i++)
		{
			visibleCards.Deck[i] = deck.GetNextCard();
			InvokeCardChangeEvents(i);
		}
	}

	public void updateCard()
	{
		visibleCards.Deck[selectedCard.Position] = deck.GetNextCard();
		InvokeCardChangeEvents(selectedCard.Position);
	}

	private void InvokeCardChangeEvents(int i)
	{
		switch (i)
		{
			case 0:
				OnFirstCardChange?.Invoke();
				break;
			case 1:
				OnSecondCardChange?.Invoke();
				break;
			case 2:
				OnThirdCardChange?.Invoke();
				break;
		}
	}
}

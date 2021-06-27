using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private DeckScriptable deck;
	[SerializeField] private DeckScriptable visibleCards;

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
		}
	}
}

using UnityEngine;

public class DeckController : MonoBehaviour
{
	[SerializeField] private DeckScriptable deck;
	[SerializeField] private DeckScriptable visibleCards;

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
			switch (i)
			{
				case 0:
					OnFirstCardChange();
					break;
				case 1:
					OnSecondCardChange();
					break;
				case 2:
					OnThirdCardChange();
					break;
			}
		}
	}
}

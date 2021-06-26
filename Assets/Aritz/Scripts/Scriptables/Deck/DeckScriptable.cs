using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "GJ/Deck")]
public class DeckScriptable : ScriptableObject
{
	[SerializeField] private List<CardScriptable> deck;
	private int currentPosition;

	private void OnEnable()
	{
		currentPosition = 0;
	}

	public void Shuffle()
	{
		var count = deck.Count;
		var last = count - 1;
		for (var i = 0; i < last; ++i)
		{
			var r = Random.Range(i, count);
			var tmp = deck[i];
			deck[i] = deck[r];
			deck[r] = tmp;
		}
	}

	public CardScriptable GetNextCard()
	{
		var card = deck[currentPosition];
		currentPosition += 1;
		if(currentPosition > deck.Count - 1)
		{
			Shuffle();
			currentPosition = 0;
		}
		return card;
	}
}
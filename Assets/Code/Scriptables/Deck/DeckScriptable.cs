using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "GJ/Deck")]
public class DeckScriptable : ScriptableObject
{
	[SerializeField] private List<CardScriptable> deck;
	private int currentPosition;

	public List<CardScriptable> Deck { get => deck; set => deck = value; }

	public void Shuffle()
	{
		var count = Deck.Count;
		var last = count - 1;
		for (var i = 0; i < last; ++i)
		{
			var r = Random.Range(i, count);
			var tmp = Deck[i];
			Deck[i] = Deck[r];
			Deck[r] = tmp;
		}
	}

	public CardScriptable GetNextCard()
	{
		var card = Deck[currentPosition];
		currentPosition += 1;
		if(currentPosition > Deck.Count - 1)
		{
			Shuffle();
			currentPosition = 0;
		}
		return card;
	}
}
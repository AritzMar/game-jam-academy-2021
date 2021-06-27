using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CardSelectables : MonoBehaviour
{
	[Range(0, 2)]
	[SerializeField] private int index;
	[SerializeField] private SelectedCardScriptable selectedCard;
	[SerializeField] private DeckScriptable visibleCards;

	private void OnTriggerEnter(Collider other)
	{
		var newParent = other.transform.GetChild(0).transform;
		transform.position =newParent.position;
		transform.parent = newParent;
		transform.DOScale(Vector3.one * 11, 0.4f);
	}
}
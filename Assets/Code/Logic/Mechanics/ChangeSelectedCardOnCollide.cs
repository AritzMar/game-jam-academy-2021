using UnityEngine;
using Chtulhitos.Mechanics;
using DG.Tweening;

public class ChangeSelectedCardOnCollide : MonoBehaviour
{
	[SerializeField] private SelectedCardScriptable selectedCard;
	[SerializeField] private DeckScriptable visibleCards;
	[SerializeField] private int myIndex;
	[SerializeField] private MeshRenderer rend;
	[SerializeField] private Color selectedColor;
	private Tween runningTween;


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			string[] pickCardSounds = new string[] { "GJA_Pick_Card_01", "GJA_Pick_Card_02", "GJA_Pick_Card_03" };
			PlaySoundResources.PlaySound_String(pickCardSounds[Random.Range(0, pickCardSounds.Length - 1)]);

			selectedCard.SelectedCard = visibleCards.Deck[myIndex];
			other.GetComponent<Movement>().ActivateHeadGO(myIndex);
			selectedCard.Position = myIndex;
			if (runningTween == null)
			{
				runningTween = rend.material.DOColor(selectedColor, 0.5f).SetLoops(2, LoopType.Yoyo);
				runningTween.onComplete += () => runningTween = null;
			}
		}
	}
}
using UnityEngine;

public class TestCardEffects : MonoBehaviour
{
	public CardScriptable card;

	public void TriggerEffect() => card.Effect();
}

using UnityEngine;

public class TestCardEffects : MonoBehaviour
{
	public CardScriptable card;
	public RequirementsContainerScriptable playerPunctuations;

	public void TriggerEffect()
	{
		RequirementScriptable req = playerPunctuations.CompareRequirementName(card.RequirementName.name);
		card.Effect(req);
	}
}

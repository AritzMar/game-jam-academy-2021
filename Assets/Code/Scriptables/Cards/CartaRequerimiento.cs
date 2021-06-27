using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Control Card", menuName = "GJ/Cards/Requirement")]
public class CartaRequerimiento : CardScriptable
{
	[SerializeField] private Operation operation;
	[SerializeField] private int opValue;
	[SerializeField] private RequirementTypeScriptable requirementName;
	public Operation Operation { get => operation;}
	public int OpValue { get => opValue;}
	public RequirementTypeScriptable RequirementName { get => requirementName;}

	private void OnEnable()
	{
		MyCardType = CardType.RequirementEffect;
	}

	public override void Effect()
	{
		RequirementScriptable requirement = playerContainer.CompareRequirementName(requirementName.name);

		switch (Operation)
		{
			case Operation.Add:
				requirement.CurrentValue += OpValue;
				break;
			case Operation.Substract:
				requirement.CurrentValue -= OpValue;
				break;
			case Operation.Multiply:
				requirement.CurrentValue *= OpValue;
				break;
		}
	}
}
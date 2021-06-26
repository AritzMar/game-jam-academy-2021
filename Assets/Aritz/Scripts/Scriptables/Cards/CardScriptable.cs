using UnityEngine;

[CreateAssetMenu(fileName ="New Card", menuName ="GJ/Card")]
public class CardScriptable : ScriptableObject
{
	[SerializeField] private RequirementTypeScriptable requirementName;
	[SerializeField] private Operation op;
	[SerializeField] private int opValue;

	public RequirementTypeScriptable RequirementName { get => requirementName; set => requirementName = value; }

	public void Effect(RequirementScriptable requirement)
	{
		switch (op)
		{
			case Operation.Add:
				requirement.CurrentValue += opValue;
				break;
			case Operation.Substract:
				requirement.CurrentValue -= opValue;
				break;
			case Operation.Multiply:
				requirement.CurrentValue *= opValue;
				break;
		}
	}
}
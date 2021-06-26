using UnityEngine;

[CreateAssetMenu(fileName = "new Requirement", menuName = "GJ/Requirements/Requirement")]
public class RequirementScriptable : IntVariable
{
	[SerializeField] private int minValue;
	[SerializeField] private int maxValue;
	[SerializeField] private RequirementTypeScriptable requirementName;
	
	public int MinValue { get => minValue; }
	public int MaxValue { get => maxValue; }
	public RequirementTypeScriptable RequirementName { get => requirementName; set => requirementName = value; }
}
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new Requirement", menuName = "GJ/Requirements/Requirements Container")]
public class RequirementsContainerScriptable : ScriptableObject
{
	// Exigencias
	[SerializeField] private RequirementScriptable[] requirements;
	
	public RequirementScriptable[] Requirements { get => requirements; set => requirements = value; }

	public RequirementScriptable CompareRequirementName(string name) => 
		Array.Find(requirements, n => String.Equals(n.RequirementName.name, name));

	public void RandomizeRequirements()
	{
		foreach (RequirementScriptable requirement in requirements)
			requirement.CurrentValue = UnityEngine.Random.Range(requirement.MinValue, requirement.MaxValue);
	}
}
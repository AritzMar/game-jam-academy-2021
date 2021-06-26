using UnityEngine;

[CreateAssetMenu(fileName = "new Requirement Name", menuName = "GJ/Requirements/Name")]
public class RequirementTypeScriptable : ScriptableObject
{
	[SerializeField] private string _name;
	public string RequirementName { get => _name;}
}
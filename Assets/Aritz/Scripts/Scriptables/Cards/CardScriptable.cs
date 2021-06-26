using UnityEngine;

public abstract class CardScriptable : ScriptableObject
{
	[SerializeField] protected RequirementsContainerScriptable playerContainer;
	[SerializeField] protected RequirementsContainerScriptable bossContainer;
	public RequirementsContainerScriptable PlayerContainer { get => playerContainer; set => playerContainer = value; }
	public RequirementsContainerScriptable BossContainer { get => bossContainer; set => bossContainer = value; }

	public abstract void Effect();
}
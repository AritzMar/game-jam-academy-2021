using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Control Card", menuName = "GJ/Cards/Control")]
public class CartaControl : CardScriptable
{
	[SerializeField] private ControlType controlType;
	[SerializeField] private IntVariable turnTime;
	public ControlType ControlType { get => controlType; set => controlType = value; }
	public IntVariable TurnTime { get => turnTime; set => turnTime = value; }

	public override void Effect()
	{
		if (controlType == ControlType.ClampAll)
		{
			foreach (RequirementScriptable req in playerContainer.Requirements)
			{
				var bossReq = bossContainer.CompareRequirementName(req.RequirementName.name);

				if (req.CurrentValue > bossReq.CurrentValue)
					req.CurrentValue = bossReq.CurrentValue;
			}
		}

		if (controlType == ControlType.AddTime)
			TurnTime.CurrentValue += 5;
	}
}
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Control Card", menuName = "GJ/Cards/Minigame")]
public class CartaMinijuego : CardScriptable
{
	[Header("VARIABLES AFECTADAS")]
	[SerializeField] private List<RequirementTypeScriptable> requirementNames;

	// Efecto positivo
	[Header("EFFECTO POSITIVO")]
	[SerializeField] private Operation goodOperation;
	[SerializeField] private int goodValue;
	private RequirementTypeScriptable goodName;

	// Efecto adverso
	[Header("EFFECTO NEGATIVO")]
	[SerializeField] private Operation badOperation;
	[SerializeField] private int badValue;
	private RequirementTypeScriptable badName;

	// Minijuego sobre el que aplicar el +1 de dificultad
	[Header("VARIABLE DEL MINIJUEGO AFECTADA")]
	[SerializeField] private IntVariable miniGameDifficult;

	private void Awake()
	{
		goodName = requirementNames[Random.Range(0, requirementNames.Count)];
		badName = requirementNames[Random.Range(0, requirementNames.Count)];
	}

	public override void Effect()
	{
		// Comunicacion con el state pattern??
		if (true)
		{
			performOperation(goodOperation, goodValue, goodName);
			UpdateDifficult();
		}
		else
			performOperation(badOperation, badValue, badName);
	}

	private void performOperation(Operation op, int val, RequirementTypeScriptable reqName)
	{
		RequirementScriptable requirement = playerContainer.CompareRequirementName(reqName.name);

		switch (op)
		{
			case Operation.Add:
				requirement.CurrentValue += val;
				break;
			case Operation.Substract:
				requirement.CurrentValue -= val;
				break;
			case Operation.Multiply:
				requirement.CurrentValue *= val;
				break;
		}
	}

	private void UpdateDifficult() => miniGameDifficult.CurrentValue += 1;

}
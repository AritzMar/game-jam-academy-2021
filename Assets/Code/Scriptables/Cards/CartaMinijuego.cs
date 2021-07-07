using System.Collections.Generic;
using UnityEngine;
using Chtulhitos.Mechanics;


[CreateAssetMenu(fileName = "New Control Card", menuName = "GJ/Cards/Minigame")]
public class CartaMinijuego : CardScriptable
{
	//[Header("VARIABLES AFECTADAS")]
	//[SerializeField] private List<RequirementTypeScriptable> requirementNames;

	// Efecto positivo
	[Header("EFFECTO POSITIVO")]
	[SerializeField] private Operation goodOperation;
	[SerializeField] private int goodValue;
	[SerializeField] private RequirementTypeScriptable goodName;
	public RequirementTypeScriptable GoodName { get => goodName; }

	// Efecto adverso
	//[Header("EFFECTO NEGATIVO")]
	//[SerializeField] private Operation badOperation;
	//[SerializeField] private int badValue;
	//private RequirementTypeScriptable badName;
	//public RequirementTypeScriptable BadName { get => badName; }

	// Minijuego sobre el que aplicar el +1 de dificultad
	[Header("VARIABLE DEL MINIJUEGO AFECTADA")]
	[SerializeField] private IntVariable miniGameDifficult;

	public Operation GoodOperation { get => goodOperation; set => goodOperation = value; }
	public int GoodValue { get => goodValue; set => goodValue = value; }
	//public Operation BadOperation { get => badOperation; set => badOperation = value; }
	//public int BadValue { get => badValue; set => badValue = value; }


	private void OnEnable()
	{
		MyCardType = CardType.MiniGame;
	}

	//private void Awake()
	//{
	//	goodName = requirementNames[Random.Range(0, requirementNames.Count)];
	//	badName = requirementNames[Random.Range(0, requirementNames.Count)];
	//}

	public override void Effect()
	{
		Debug.Log("2");
		performOperation(GoodOperation, GoodValue, goodName);
		UpdateDifficult();
	}

	//public void BadEffect()
	//{
	//	Debug.Log("1");
	//	performOperation(BadOperation, badValue, badName);
	//}


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
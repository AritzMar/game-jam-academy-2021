using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private GameStates gameStates;
	[SerializeField] private Round round;
	[SerializeField] private Flow flow;
	[SerializeField] private IntVariable timeForBreak;

	public void RestartGame()
	{
		StartCoroutine(Start());
	}

	private IEnumerator Start()
	{
		PerformState("Starting");

		//yield return new WaitUntil(() => flow.GetFlowModifierByName("Tutorial").Performed);

		PerformState("Waiting");

		yield return new WaitUntil(() => flow.GetFlowModifierByName("Answers").Performed);

		yield return StartCoroutine(RoundLoop());

		PerformState("Finished");
	}

	private IEnumerator RoundLoop()
	{
		if(round.CurrentRound == round.MaxRound)
			yield break;

		while(round.CurrentRound < round.MaxRound)
		{
			PerformState("Playing");
			
			yield return new WaitUntil(() => flow.GetFlowModifierByName("Ended").Performed);
			PerformState("EndTurn");

			round.CurrentRound++;

			PerformState("Waiting");
			yield return new WaitUntil(() => flow.GetFlowModifierByName("Answers").Performed);

		}
	}

	public void PerformState(string state)
	{
		GameState tempLogic = gameStates.ObtainEventWithLogic(state);
		Debug.Log(tempLogic);
		tempLogic?.Raise(state);
	}
}

using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameStates gameStates;
    [SerializeField] private Round round;
    [SerializeField] private Flow flow;
    [SerializeField] private IntVariable timeForBreak;

    private IEnumerator Start()
    {
        PerformState("Starting");

        yield return new WaitUntil(() => flow.GetFlowModifierByName("Tutorial").Performed);

        PerformState("Waiting");

        yield return new WaitUntil(() => flow.GetFlowModifierByName("Answers").Performed);

        yield return StartCoroutine(RoundLoop());

        Debug.Log("Fin del juego");

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

            yield return new WaitForSeconds(timeForBreak.CurrentValue);
        }

        PerformState("Finished");
        Debug.Log("Fin del juego");
    }

    public void PerformState(string state)
    {
        GameState tempLogic = gameStates.ObtainEventWithLogic(state);
        tempLogic?.Raise(state);
    }
}

using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] private GameStates gameStates;

    // private void OnEnable()
    // {
    //     Timer.OnTimerStarted += () => SetGameState("Waiting");
    //     Timer.OnTimerEnded +=   () => SetGameState("Finished");
    // }

    // private void OnDisable() 
    // {
    //     Timer.OnTimerStarted -= () => SetGameState("Waiting");
    //     Timer.OnTimerEnded -= () => SetGameState("Finished");
    // }

    public void PerformState(string state)
    {
        GameState tempLogic = gameStates.ObtainEventWithLogic(state);
        tempLogic?.Raise(state);
    }
}

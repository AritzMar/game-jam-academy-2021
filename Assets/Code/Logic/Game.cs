using UnityEngine;

public class Game : MonoBehaviour
{
    private IGameState currentGameState;

    public void GameIsStarting()
    {
        currentGameState = new StartingState();
        currentGameState.Perform(this);
    }

    public void GameIsWaiting()
    {
        currentGameState = new WaitingState();
        currentGameState.Perform(this);
    }

    public void GameIsEndingTurn()
    {
        currentGameState = new EndingTurnState();
        currentGameState.Perform(this);
    }

    public void GameIsFinished()
    {
        currentGameState = new FinishedState();
        currentGameState.Perform(this);
    }
}

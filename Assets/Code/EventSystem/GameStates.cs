using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new GameStates", menuName = "GJ/Game/List Of States", order = 0)]
public class GameStates : ScriptableObject 
{
    [System.Serializable]
    public class GameLogic
    {
        public GameState Delegate;
    }
    [SerializeField] private GameLogic[] gameLogics;
    
    
    public GameState ObtainEventWithLogic(string State)
    {
        GameLogic logicToObtain = Array.Find(gameLogics, l => l.Delegate.name == State);
        if(logicToObtain != null)
            return logicToObtain.Delegate;
		else
            return null;
    }

    public void FindAndPerform(string states)
    {
        GameLogic tempLogic = Array.Find(gameLogics, g => g.Delegate.name == states);
        tempLogic?.Delegate.Raise(states);
    }
}
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "new GameState", menuName = "GJ/Game/Game State")]
public class GameState : ScriptableObject 
{
	private List<StateListener> listeners;

	public void Subscribe(StateListener listener)
	{
		if (!listeners.Contains(listener))
			listeners.Add(listener);
	}

	public void Unsubscribe(StateListener listener)
	{

		if (listeners.Contains(listener))
			listeners.Remove(listener);
	}

	public void Raise(string state)
	{
		foreach (StateListener listener in listeners)
			listener?.Fire(state);

	}
}
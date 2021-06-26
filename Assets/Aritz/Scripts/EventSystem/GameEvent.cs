using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "GJ/Events/Game Event")]
public class GameEvent : ScriptableObject
{
	private List<EventListener> listeners;

	public void Subscribe(EventListener listener)
	{
		if (!listeners.Contains(listener))
			listeners.Add(listener);
	}

	public void Unsubscribe(EventListener listener)
	{
		if (listeners.Contains(listener))
			listeners.Remove(listener);
	}

	public void Fire()
	{
		foreach (EventListener listener in listeners)
			listener.Fire();
	}
}

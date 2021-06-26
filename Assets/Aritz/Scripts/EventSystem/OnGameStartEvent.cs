using UnityEngine;
public class OnGameStartEvent : BaseEvent
{
	private void Start()
	{
		gameEvent.Fire();
	}
}
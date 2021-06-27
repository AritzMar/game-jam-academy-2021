using UnityEngine;
using UnityEngine.Events;
using System;

public class StateListener : MonoBehaviour {

    [System.Serializable]
    public class StateToPerform
    {        
        public GameState State;
        public UnityEvent Events;
    }

    [SerializeField] private StateToPerform[] StatesEvents;
	[SerializeField] private GameStates GameStates;

	private void OnEnable()
    {
        for (int i = 0; i < StatesEvents.Length; i++)
        {
            GameState tempGameEvent = GameStates.ObtainEventWithLogic(StatesEvents[i].State.name);
            tempGameEvent.Subscribe(this);
        }
    }

	private void OnDisable()
    {
        for (int i = 0; i < StatesEvents.Length; i++)
        {
            GameState tempGameEvent = GameStates.ObtainEventWithLogic(StatesEvents[i].State.name);
            tempGameEvent.Unsubscribe(this);
        }
    }

    public void Fire(string state)
    {
        StateToPerform targetState = Array.Find(StatesEvents, e => e.State.name == state);
        targetState?.Events.Invoke();
    }
}
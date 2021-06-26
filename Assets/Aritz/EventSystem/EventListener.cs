using UnityEngine.Events;
using UnityEngine;

public class EventListener : MonoBehaviour
{
	[SerializeField] private UnityEvent events;
	[SerializeField] private GameEvent gameEvent;

	private void OnEnable() => gameEvent.Subscribe(this);
	private void OnDisable() => gameEvent.Unsubscribe(this);
	public void Fire() => events?.Invoke();
}
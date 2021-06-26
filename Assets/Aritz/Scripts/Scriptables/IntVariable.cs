using UnityEngine;

[CreateAssetMenu(fileName ="new Int Variable", menuName ="GJ/Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
	public System.Action OnValueChange { get; set; }

	[SerializeField] private int initialValue;
	private int currentValue;

	public int CurrentValue
	{
		get => currentValue;
		set
		{ 
			currentValue = value; 
			OnValueChange?.Invoke();
		}
	}

	private void OnEnable() => CurrentValue = initialValue;
	private void OnValidate() => OnValueChange?.Invoke();
}
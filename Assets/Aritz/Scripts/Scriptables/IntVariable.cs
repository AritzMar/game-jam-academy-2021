using UnityEngine;

[CreateAssetMenu(fileName ="new Int Variable", menuName ="GJ/Variables/Int Variable")]
public class IntVariable : ScriptableObject
{
	public System.Action<int> OnValueChange { get; set; }

	[SerializeField] private int initialValue;
	private int currentValue;

	public int CurrentValue
	{
		get => currentValue;
		set
		{ 
			currentValue = value; 
			OnValueChange?.Invoke(value);
		}
	}

	private void OnEnable() => CurrentValue = initialValue;
	//private void OnValidate() => OnValueChange?.Invoke();

	public void ResetCurrentToInitial() => CurrentValue = initialValue;
}
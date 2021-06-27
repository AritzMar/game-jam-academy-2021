using UnityEngine;

[CreateAssetMenu(fileName = "new FloatVariable", menuName = "GJ/Variables/Float Variable", order = 0)]
public class FloatVariable : ScriptableObject 
{
	[SerializeField] private int initialValue;
	private int currentValue;

	public int CurrentValue
	{
		get => currentValue;
		set
		{ 
			currentValue = value; 
		}
	}

	private void OnEnable() => CurrentValue = initialValue;

    public void ResetCurrentToInitial() => CurrentValue = initialValue;
}
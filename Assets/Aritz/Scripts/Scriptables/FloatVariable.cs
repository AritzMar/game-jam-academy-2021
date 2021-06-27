using UnityEngine;

[CreateAssetMenu(fileName = "new FloatVariable", menuName = "GJ/Variables/Float Variable", order = 0)]
public class FloatVariable : ScriptableObject 
{
	[SerializeField] private float initialValue;
	private float currentValue;

	public float CurrentValue
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
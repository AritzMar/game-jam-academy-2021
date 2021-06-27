using UnityEngine;

[CreateAssetMenu(fileName = "new Round", menuName = "GJ/Game/Round")]
public class Round : ScriptableObject 
{
	public System.Action<int> OnRoundChange { get; set; }
	[SerializeField] private int currentRound;
	public int MaxRound;

	public int CurrentRound
	{
		get => currentRound;
		set
		{
			currentRound = Mathf.Clamp(value, Vector3Int.zero.x, MaxRound);
			OnRoundChange?.Invoke(currentRound + 1);
		}
	}

	private void OnEnable() => CurrentRound = 0;
	public void RoundUp() => CurrentRound += 1;
	public void ResetValue() => currentRound = 0;
}
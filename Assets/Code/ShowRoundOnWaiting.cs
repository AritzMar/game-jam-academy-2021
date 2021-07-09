using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ShowRoundOnWaiting : MonoBehaviour
{
	[SerializeField] private Round currentRound;
	[SerializeField] private TextMeshProUGUI text;

	private void OnEnable()
	{
		text.text = $"Round {currentRound.CurrentRound + 1} of {currentRound.MaxRound}";
	}
}

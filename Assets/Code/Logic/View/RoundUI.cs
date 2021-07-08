using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundUI : MonoBehaviour
{
	public Round RoundValue;
	public TextMeshProUGUI RoundLabel;

	 private void Start() 
	{
		ChangeRoundText(RoundValue.CurrentRound);
	}

	private void OnEnable() 
	{
		RoundValue.OnRoundChange += ChangeRoundText;
	}

	private void OnDisable() 
	{
		RoundValue.OnRoundChange -= ChangeRoundText;
	}

	private void ChangeRoundText(int round)
	{
		if(round < RoundValue.MaxRound)
			RoundLabel.text = (round + 1).ToString();
	}
}

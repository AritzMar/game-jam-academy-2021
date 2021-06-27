using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundUI : MonoBehaviour
{
    public Round RoundValue;
    public TMP_Text RoundLabel;

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
        RoundLabel.text = round.ToString();
    }
}

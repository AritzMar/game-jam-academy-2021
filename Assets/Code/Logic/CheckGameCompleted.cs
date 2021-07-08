using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameEndStatus { 
	Win, 
	EpicWin, 
	Lose};

public class CheckGameCompleted : MonoBehaviour
{
	[SerializeField] private RequirementsContainerScriptable playerReq;
	[SerializeField] private RequirementsContainerScriptable bossReq;
	[SerializeField] private TextMeshProUGUI endText;
	[TextArea, SerializeField] private string LoseText;
	[TextArea, SerializeField] private string WinText;
	[TextArea, SerializeField] private string EpicWinText;

	public GameEndStatus CheckEnd()
	{
		List<int> differences = new List<int>();
		
		foreach (RequirementScriptable req in playerReq.Requirements)
		{
			var other = Array.Find(bossReq.Requirements, r => string.Compare(r.RequirementName.RequirementName, req.RequirementName.RequirementName) == 0);
			differences.Add(req.CurrentValue - other.CurrentValue);
		}

		if (differences.FindAll(r => r == 0).Count == 4)
			return GameEndStatus.EpicWin;
		else if (differences.FindAll(r => r >= 0).Count == 4)
			return GameEndStatus.Win;
		else
			return GameEndStatus.Lose;
	}

	public void ChangeEndText()
	{
		switch (CheckEnd())
		{
			case GameEndStatus.EpicWin:
				endText.text = EpicWinText;
				break;
			case GameEndStatus.Win:
				endText.text = WinText;
				break;
			case GameEndStatus.Lose:
				endText.text = LoseText;
				break;
		}
	}
}
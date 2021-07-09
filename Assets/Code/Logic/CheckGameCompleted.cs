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

	private List<string> calledPerfectReqNames = new List<string>();
	private List<string> calledSuperiorReqNames = new List<string>();

	public GameEndStatus CheckEnd()
	{
		List<int> differences = new List<int>();
		
		foreach (RequirementScriptable req in playerReq.Requirements)
		{
			var name = req.RequirementName.RequirementName;
			var other = Array.Find(bossReq.Requirements, r => string.Compare(r.RequirementName.RequirementName, name) == 0);
			var diff = req.CurrentValue - other.CurrentValue;
			differences.Add(diff);

			// Se lanza el evento cuando deja perfecto un req
			if (diff == 0 && !calledPerfectReqNames.Contains(name))
			{
				DialogEvents.OnReqPerfect?.Invoke(name);
				calledPerfectReqNames.Add(name);
			}

			//if (diff > 0 && !calledSuperiorReqNames.Contains(name))
			//{
			//	DialogEvents.OnReqSobrepasado?.Invoke(name);
			//	calledSuperiorReqNames.Add(name);
			//}
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
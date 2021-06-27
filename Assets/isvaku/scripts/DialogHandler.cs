using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DialogHandler : MonoBehaviour
{
	public GameObject Panel;
	public Dialog_library Library;
	public TMP_Text DialogTextUI;
	public FlowHandler flowHandler;

	private int dialogCount;
	private int dialogMax = 3;

	public void SetDialogAnswer(string condition)
	{
		StartCoroutine(DisplayAnswers(condition));
	}

	private IEnumerator DisplayAnswers(string condition)
	{
		if(dialogCount == 0)
		{
			Panel.transform.DOScale(Vector3.one, 2f);
		}

		while(dialogCount < 3)
		{
			List<string> obtainedDialogs = Library.GetDialogsBySituation(condition);
			DialogTextUI.text = obtainedDialogs[Random.Range(0, obtainedDialogs.Count)];

			dialogCount++;

			yield return new WaitForSeconds(2f);
		}

		flowHandler.PerformAModifier();
		dialogCount = 0;
		Panel.transform.DOScale(Vector3.zero, 2f);
		yield break;
	}

	public void SetDialog(string condition)
	{
		List<string> obtainedDialogs = Library.GetDialogsBySituation(condition);
		DialogTextUI.text = obtainedDialogs[Random.Range(0, obtainedDialogs.Count)];
	}
}
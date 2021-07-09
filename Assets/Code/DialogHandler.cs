using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DialogHandler : MonoBehaviour
{
	public GameObject Panel;
	public Dialog_library Library;
	public TMP_Text DialogTextUI;
	public FlowHandler flowHandler;

	private int dialogCount = 0;
	private int dialogMax = 1;
	private Coroutine TextDisplayCorutine = null;

	private void OnEnable()
	{
		DialogEvents.OnReqPerfect += WhenPerfectMatch;
		DialogEvents.OnPlayerGetHit += WhenHit;
		// DialogEvents.OnReqSobrepasado += WhenSobrepasado;
	}

	private void OnDisable()
	{
		DialogEvents.OnReqPerfect -= WhenPerfectMatch;
		DialogEvents.OnPlayerGetHit -= WhenHit;
		// DialogEvents.OnReqSobrepasado -= WhenSobrepasado;
	}

	public void SetDialogAnswer(string condition)
	{
		if (TextDisplayCorutine != null)
			StopCoroutine(TextDisplayCorutine);
		
		TextDisplayCorutine = StartCoroutine(DisplayAnswers(condition));
	}

	public void SayOneSentence(string condition)
	{
		if (TextDisplayCorutine == null)
			TextDisplayCorutine = StartCoroutine(DisplayOne(condition));
	}

	// Cambiar esta funcion para que solo hable una vez y haya otra que llame 3 veces
	// y active el modificador. Si no puede darse el caso en el que haya rondas que se salten
	private IEnumerator DisplayAnswers(string condition)
	{
		if(dialogCount == 0)
			Panel.transform.DOScale(Vector3.one, 1f);

		while(dialogCount < 3)
		{
			List<string> obtainedDialogs = Library.GetDialogsBySituation(condition);
			DialogTextUI.text = obtainedDialogs[Random.Range(0, obtainedDialogs.Count)];

			dialogCount++;

			yield return new WaitForSeconds(2f);
		}

		flowHandler.PerformAModifier();

		dialogCount = 0;

		Panel.transform.DOScale(Vector3.zero, 1f);

		TextDisplayCorutine = null;

		yield break;
	}

	private IEnumerator DisplayOne(string condition)
	{
		Panel.transform.DOScale(Vector3.one, 1f);

		List<string> obtainedDialogs = Library.GetDialogsBySituation(condition);
		DialogTextUI.text = obtainedDialogs[Random.Range(0, obtainedDialogs.Count)];

		yield return new WaitForSeconds(2f);

		Panel.transform.DOScale(Vector3.zero, 1f);

		TextDisplayCorutine = null;

		yield break;
	}


	public void SetDialog(string condition)
	{
		List<string> obtainedDialogs = Library.GetDialogsBySituation(condition);
		DialogTextUI.text = obtainedDialogs[Random.Range(0, obtainedDialogs.Count)];
	}

	// Event functions
	private void WhenPerfectMatch(string reqName) => SayOneSentence(reqName);
	private void WhenHit() => SayOneSentence("Bad");
	private void WhenSobrepasado(string reqName) => SayOneSentence(reqName + " S");

}
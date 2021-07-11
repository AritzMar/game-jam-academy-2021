using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class ApplyCardEffectOnCollide : MonoBehaviour
{
	[SerializeField] private SelectedCardScriptable selectedCard;
	[SerializeField] private Game gameManager;
	[SerializeField] private CheckGameCompleted gameChecker;
	[Space]
	[SerializeField] private UnityEvent onEnteredWithCard;

	private void OnTriggerEnter(Collider other)
	{
		if(selectedCard.SelectedCard != null)
		{
			StartCoroutine(WaitTOSuccessSound(0.5f));
			string[] dropSounds = new string[] { "GJA_Drop_Card_1", "GJA_Drop_Card_2", "GJA_Drop_Card_3"};
			PlaySoundResources.PlaySound_String(dropSounds[Random.Range(0, dropSounds.Length - 1)]);

			selectedCard.SelectedCard.Effect();
			selectedCard.SelectedCard = null;
			onEnteredWithCard?.Invoke();

			GameEndStatus ge = gameChecker.CheckEnd();

			if (ge == GameEndStatus.EpicWin || ge == GameEndStatus.Win)
				gameManager.PerformState("Finished");
		}
	}
	private IEnumerator WaitTOSuccessSound(float waitTime)
	{
		string[] successSounds = new string[] { "GJA_Sucess_1", "GJA_Sucess_2", "GJA_Sucess_3", "GJA_Sucess_4" };
		yield return new WaitForSeconds(waitTime);
		PlaySoundResources.PlaySound_String(successSounds[Random.Range(0, successSounds.Length - 1)]);
	}

}
using UnityEngine;
using TMPro;


public class CardEffectPlayerScoreTest : MonoBehaviour
{
	public IntVariable scoreScriptable;
	public TextMeshProUGUI tmproUI;

	private void OnEnable()
	{
		scoreScriptable.OnValueChange += (a) => ChangeValue(a);
	}

	private void OnDisable()
	{
		scoreScriptable.OnValueChange -= (a) => ChangeValue(a);
	}

	private void Start()
	{
		ChangeValue(1);
	}

	private void ChangeValue(int a) => tmproUI.text = scoreScriptable.CurrentValue.ToString();
}

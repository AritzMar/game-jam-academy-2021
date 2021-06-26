using UnityEngine;
using TMPro;


public class CardEffectPlayerScoreTest : MonoBehaviour
{
	public IntVariable scoreScriptable;
	public TextMeshProUGUI tmproUI;

	private void OnEnable()
	{
		scoreScriptable.OnValueChange += () => ChangeValue();
	}

	private void OnDisable()
	{
		scoreScriptable.OnValueChange -= () => ChangeValue();
	}

	private void Start()
	{
		ChangeValue();
	}

	private void ChangeValue() => tmproUI.text = scoreScriptable.CurrentValue.ToString();
}

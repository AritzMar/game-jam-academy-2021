using UnityEngine;
using TMPro;

public class RequirementTest : MonoBehaviour
{
	[SerializeField] private RequirementsContainerScriptable exigencias;
	[SerializeField] private TextMeshProUGUI uiText;

	private void Start()
	{
		exigencias.Requirements[0].OnValueChange += (a) => OnValueChanged(a);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			Shuffle();
	}

	private void Shuffle()
	{
		exigencias.RandomizeRequirements();
		for (int i = 0; i < exigencias.Requirements.Length; i++)
			Debug.Log(exigencias.Requirements[i].CurrentValue);
	}

	public void OnValueChanged(int a) => uiText.text = exigencias.Requirements[0].CurrentValue.ToString();

}
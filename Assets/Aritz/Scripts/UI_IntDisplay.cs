using UnityEngine;
using TMPro;

public class UI_IntDisplay : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI textUI;
	[SerializeField] private IntVariable requirement;

	private void Start()
	{
		textUI.text = requirement.CurrentValue.ToString();
		requirement.OnValueChange += (val) => UpdateValue(requirement.CurrentValue);
	}

	private void UpdateValue(int val) => textUI.text = val.ToString();
}

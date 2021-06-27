using UnityEngine;

[CreateAssetMenu(fileName ="new Selected Card", menuName ="GJ/Player/Selected Card")]
public class SelectedCardScriptable : ScriptableObject
{
	public int Position { get; set; }
	public CardScriptable SelectedCard { get; set; }
}

using UnityEngine;

[CreateAssetMenu(fileName ="new Selected Card", menuName ="GJ/Player/Selected Card")]
public class SelectedCardScriptable : ScriptableObject
{
	public int Position { get; set; }
	public CardScriptable SelectedCard { get; set; }

	public CardType MyType { get => SelectedCard.MyCardType; }


	private void OnEnable()
	{
		SelectedCard = null;
	}

	public void Reset() => SelectedCard = null;
}

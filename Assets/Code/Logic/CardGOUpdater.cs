using UnityEngine;
using TMPro;

public class CardGOUpdater : MonoBehaviour
{
	public MeshRenderer meshRenderer;
	public Material expMat;
	public Material techMat;
	public Material softMat;
	public Material portMat;
	public DeckScriptable visibleCards;
	public DeckController DeckController;
	public TextMeshPro cardText;

	[Range(0,2)]
	public int myIndex;

	private void Start()
	{
		if(myIndex == 0)
			DeckController.OnFirstCardChange += () => ChangeCardVisuals();
		if (myIndex == 1)
			DeckController.OnSecondCardChange += () => ChangeCardVisuals();
		if (myIndex == 2)
			DeckController.OnThirdCardChange += () => ChangeCardVisuals();
	}

	private void ChangeCardVisuals()
	{
		CardScriptable card = visibleCards.Deck[myIndex];
		

		if(card.MyCardType == CardType.RequirementEffect)
		{
			CartaRequerimiento c = (CartaRequerimiento)card;

			switch (c.RequirementName.RequirementName)
			{
				case "Experiencia":
					meshRenderer.materials[0].mainTexture = expMat.mainTexture;
					meshRenderer.materials[1].mainTexture = expMat.mainTexture;
					break;

				case "Portfolio":
					meshRenderer.materials[0].mainTexture = portMat.mainTexture;
					meshRenderer.materials[1].mainTexture = portMat.mainTexture;
					break;

				case "Soft Skill":
					meshRenderer.materials[0].mainTexture = softMat.mainTexture;
					meshRenderer.materials[1].mainTexture = softMat.mainTexture;
					break;

				default:
					meshRenderer.materials[0].mainTexture = techMat.mainTexture;
					meshRenderer.materials[1].mainTexture = techMat.mainTexture;
					break;
			}

			string cText = "";
			if (c.Operation == Operation.Add)
				cText += '+';
			if (c.Operation == Operation.Multiply)
				cText += 'x';
			if (c.Operation == Operation.Substract)
				cText += '-';

			cText += c.OpValue.ToString();

			cardText.text = cText;
		}
	}
}

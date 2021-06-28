using UnityEngine;
using TMPro;

public class CardGOUpdater : MonoBehaviour
{
	public MeshRenderer meshRenderer;
	public Material expMat;
	public Material techMat;
	public Material softMat;
	public Material portMat;
	public Material backMaterial;
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
					ChangeMaterial(expMat);
					break;

				case "Portfolio":
					ChangeMaterial(portMat);
					break;

				case "Soft Skill":
					ChangeMaterial(softMat);
					break;

				default:
					ChangeMaterial(techMat);
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

	public void ResetCardVisuals()
	{
		ChangeMaterial(backMaterial);
		cardText.text = "";
	}

	private void ChangeMaterial(Material mat)
	{
		var mats = meshRenderer.materials;
		mats[0] = mat;
		mats[1] = mat;
		meshRenderer.materials = mats;
	}
}

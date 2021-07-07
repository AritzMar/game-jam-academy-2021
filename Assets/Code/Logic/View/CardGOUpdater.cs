using UnityEngine;
using TMPro;
using DG.Tweening;
using Chtulhitos.Mechanics;

public class CardGOUpdater : MonoBehaviour
{
	[Header("PROPERTIES")]
	[Range(0, 2), SerializeField] private int myIndex;
	[SerializeField] private MeshRenderer meshRenderer;

	[Header("MATERIALS")]
	[SerializeField] private Material expMat;
	[SerializeField] private Material techMat;
	[SerializeField] private Material softMat;
	[SerializeField] private Material portMat;
	[SerializeField] private Material minigameMat;
	[SerializeField] private Material timeMat;
	[SerializeField] private Material backMaterial;

	[Header("GLOBAL VARIABLES")]
	[SerializeField] private DeckScriptable visibleCards;
	[SerializeField] private DeckController DeckController;

	[Header("UI COMPONENTS")]
	[SerializeField] private TextMeshPro reqCardText;
	private Tween textEffectTween;

	private void OnEnable()
	{
		if(myIndex == 0)
			DeckController.OnFirstCardChange += () => ChangeCardVisuals();
		if (myIndex == 1)
			DeckController.OnSecondCardChange += () => ChangeCardVisuals();
		if (myIndex == 2)
			DeckController.OnThirdCardChange += () => ChangeCardVisuals();
	}


	private void OnDisable()
	{
		if (myIndex == 0)
			DeckController.OnFirstCardChange -= () => ChangeCardVisuals();
		if (myIndex == 1)
			DeckController.OnSecondCardChange -= () => ChangeCardVisuals();
		if (myIndex == 2)
			DeckController.OnThirdCardChange -= () => ChangeCardVisuals();
	}


	private void ChangeCardVisuals()
	{
		ResetCardVisuals();

		CardScriptable card = visibleCards.Deck[myIndex];

		switch (card.MyCardType)
		{
			case CardType.RequirementEffect:
				RequirementCardVisuals(card);
				break;
			case CardType.MiniGame:
				MinigameCardVisuals(card);
				break;
			case CardType.Control:
				ControlCardVisuals(card);
				break;
		}
	}


	public void ResetCardVisuals()
	{
		ChangeMaterial(backMaterial);
		reqCardText.text = "";
	}

	private void ControlCardVisuals(CardScriptable card)
	{
		CartaControl c = (CartaControl)card;
		ChangeMaterial(timeMat);

		if (c.ControlType == ControlType.ClampAll)
			reqCardText.text = "Clamp";
		if (c.ControlType == ControlType.AddTime)
			reqCardText.text = "";
	}

	private void RequirementCardVisuals(CardScriptable card)
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

		reqCardText.text = OperationToText(c.Operation, c.OpValue);
	}
	private void MinigameCardVisuals(CardScriptable card)
	{
		CartaMinijuego c = (CartaMinijuego)card;

		reqCardText.text = OperationToText(c.GoodOperation, c.GoodValue);
		switch (c.GoodName.RequirementName)
		{
			case "Experiencia":
				ChangeMaterial(minigameMat, expMat);
				break;

			case "Portfolio":
				ChangeMaterial(minigameMat, portMat);
				break;

			case "Soft Skill":
				ChangeMaterial(minigameMat, softMat);
				break;

			default:
				ChangeMaterial(minigameMat, techMat);
				break;
		}
	}

	private string OperationToText(Operation op, int value)
	{
		string cText = "";
		//if (op == Operation.Add)
		//	cText += '+';
		//if (op == Operation.Multiply)
		//	cText += 'x';
		//if (op == Operation.Substract)
		//	cText += '-';

		cText += value.ToString();

		return cText;
	}
	private void ChangeMaterial(Material mat)
	{
		var mats = meshRenderer.materials;
		mats[0] = mat;
		mats[1] = mat;
		meshRenderer.materials = mats;
	}
	private void ChangeMaterial(Material mat, Material mat2)
	{
		var mats = meshRenderer.materials;
		mats[0] = mat;
		mats[1] = mat2;
		meshRenderer.materials = mats;
	}
}

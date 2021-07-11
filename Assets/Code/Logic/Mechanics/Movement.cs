using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Chtulhitos.Mechanics
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class Movement : MonoBehaviour, IHiteable
	{
		[SerializeField] private NavMeshAgent agent;
		[SerializeField] private Transform startPoint;
		[SerializeField] private ParticleSystem deadEffect;
		[SerializeField] private DeckScriptable visibleCards;
		[SerializeField] private SelectedCardScriptable selectedCard;

		public static System.Action OnHit { get; set; }

		private bool canMove = false;
		public void ChangeMoveCondition(bool condition) => canMove = condition;

		[SerializeField] private int speed;
		public int Speed
		{
			get { return speed; }
			private set { speed = value; }
		}

		void Update()
		{
			agent.speed = Mathf.Clamp(agent.speed, 0, speed);
			if(canMove)
				MoveWithAgentWithARay();
		}

		private void MoveWithAgentWithARay()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit raycastHit))
			{
				agent.destination = raycastHit.point;
			}
		}

		public void TransportToStartPoint()
		{
			selectedCard.SelectedCard = null;

			Vector3 startPointLocation = new Vector3(startPoint.position.x, transform.position.y, startPoint.position.z);
			transform.position = startPointLocation;
			agent.destination = startPointLocation;
		}

		public void Hit(int damage, Vector3 position)
		{
			OnHit?.Invoke();
			DialogEvents.OnPlayerGetHit?.Invoke();

			DeactivateHeadGO();
			
			deadEffect.transform.position = position;
			deadEffect.Emit(10);
			
			StartCoroutine(WaitFailSound(0.2f));
			TransportToStartPoint();
		}
		public IEnumerator WaitFailSound(float waitTime)
		{
			string[] failSounds = new string[] { "GJA_Fail_1", "GJA_Fail_2", "GJA_Fail_3", "GJA_Fail_4" };
			yield return new WaitForSeconds(waitTime);
			PlaySoundResources.PlaySound_String(failSounds[Random.Range(0, failSounds.Length - 1)]);
		}

		public void ActivateHeadGO(int cardIndex)
		{
			CardScriptable card = visibleCards.Deck[cardIndex];
			string reqName = "";

			if (card.MyCardType == CardType.RequirementEffect)
			{
				CartaRequerimiento c = (CartaRequerimiento)card;
				reqName = c.RequirementName.RequirementName;
			}
			else if(card.MyCardType == CardType.MiniGame)
			{
				CartaMinijuego c = (CartaMinijuego)card;
				reqName = c.GoodName.RequirementName;
			}
			else if (card.MyCardType == CardType.Control)
			{
				reqName = "Time";
			}

			DeactivateHeadGO();
				
			switch (reqName)
			{
				case "Experiencia":
					transform.GetChild(3).gameObject.SetActive(true);
					break;

				case "Portfolio":
					transform.GetChild(2).gameObject.SetActive(true);
					break;

				case "Soft Skill":
					transform.GetChild(0).gameObject.SetActive(true);
					break;

				case "Time":
					transform.GetChild(4).gameObject.SetActive(true);
					break;

				default:
					transform.GetChild(1).gameObject.SetActive(true);
					break;
			}
		}

		public void DeactivateHeadGO()
		{
			for (int i = 0; i < transform.childCount - 1; i++)
				transform.GetChild(i).gameObject.SetActive(false);
		}
	}
}

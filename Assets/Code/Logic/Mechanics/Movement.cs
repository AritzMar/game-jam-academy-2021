using UnityEngine;
using UnityEngine.AI;

namespace Chtulhitos.Mechanics
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour, IHiteable
    {
        public NavMeshAgent agent;
        [SerializeField] private Transform startPoint;
        [SerializeField] private ParticleSystem deadEffect;
        [SerializeField] private DeckScriptable visibleCards;

        private bool canMove = false;
        public void ChangeMoveCondition(bool condition) => canMove = condition;

        [SerializeField] private int speed;
        public int Speed
        {
            get { return speed; }
            private set { speed = value; }
        }

        private void Start() 
        {
            agent.speed = Speed;
        }

        void Update()
        {
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
            Vector3 startPointLocation = new Vector3(startPoint.position.x, transform.position.y, startPoint.position.z);
            transform.position = startPointLocation;
            agent.destination = startPointLocation;
        }
        public void Hit(int damage)
        {
            // FALTA QUITAR LA "VIDA"
            deadEffect.transform.position = transform.position;
            deadEffect.Emit(10);
            transform.position = startPoint.position;
        }

        public void ActivateHeadGO(int cardIndex)
		{
            CardScriptable card = visibleCards.Deck[cardIndex];

            if (card.MyCardType == CardType.RequirementEffect)
            {
                CartaRequerimiento c = (CartaRequerimiento)card;

                DeactivateHeadGO();

                switch (c.RequirementName.RequirementName)
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

                    case "Tech Skill":
                        transform.GetChild(1).gameObject.SetActive(true);
                        break;
                }
            }
        }

        public void DeactivateHeadGO()
		{
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

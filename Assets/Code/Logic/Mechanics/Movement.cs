using UnityEngine;
using UnityEngine.AI;

namespace Chtulhitos.Mechanics
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        public NavMeshAgent agent;
        public LayerMask layerForRay;
        [SerializeField] private int speed;
        public int Speed
        {
            get { return speed; }
            private set { speed = value; }
        }

        private void Init()
        {
            Debug.Log("Estoy siendo ejecutado por PlayableBehaviour");
        }

        private void Waiting()
        {
            Debug.Log("Estoy esperando tambien..");
        }

        private void Start() 
        {
            agent.speed = Speed;
        }

        void Update()
        {
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
    }
}

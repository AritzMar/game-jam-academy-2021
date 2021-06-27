using UnityEngine;
using UnityEngine.AI;

namespace Chtulhitos.Mechanics
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Movement : MonoBehaviour
    {
        public NavMeshAgent agent;
        [SerializeField] private Transform startPoint;

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
    }
}

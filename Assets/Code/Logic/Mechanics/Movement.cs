using UnityEngine;
using UnityEngine.AI;

namespace Chtulhitos.Mechanics
{
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

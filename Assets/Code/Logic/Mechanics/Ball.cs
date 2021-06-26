using UnityEngine;

namespace Chtulhitos.Mechanics
{
    public class Ball : MonoBehaviour, ISpawnable
    {
        private Vector3 positionToGo;
        public Vector3 PositionToGo
        {
            get => new Vector3(transform.position.x, transform.position.y, positionToGo.z);
            set => positionToGo = value;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, PositionToGo, 5f * Time.deltaTime);
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Chtulhitos.Mechanics
{
    public class Spawner : MonoBehaviour
    {
        public float SpawnSpeed;
        public float SpawnSize;
        public Transform FinishTarget;
        public GameObject ObjectToSpawn;

        [SerializeField] private StateListener stateListener;

        private IEnumerator spawnCorrutine;

        private void Start()
        {
            spawnCorrutine = PerformSpawn();
        }

        public void StartSpawn()
        {
            StartCoroutine(spawnCorrutine);
        }

        public void StopSpawn()
        {
            StopCoroutine(spawnCorrutine);
        }

        private IEnumerator PerformSpawn()
        {
            while(true)
            {
                var instanceObject = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
                ISpawnable spawnObject = instanceObject.GetComponent<ISpawnable>();
                spawnObject.PositionToGo = FinishTarget.position;

                instanceObject.transform.SetParent(transform);
                instanceObject.transform.localPosition = new Vector3(Random.Range(-(SpawnSize / 2f), (SpawnSize / 2f)), 0f, 0f);

                yield return new WaitForSeconds(SpawnSpeed);
            }                                           
        }
    }
}


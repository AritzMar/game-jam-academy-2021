using System.Collections;
using UnityEngine;

namespace Chtulhitos.Mechanics
{
	public class Spawner : MonoBehaviour
	{
		public FloatVariable SpawnSpeed;
		public float SpawnSize;
		public Transform FinishTarget;
		public GameObject ObjectToSpawn;
		public IntVariable difficult; 

		private IEnumerator spawnCorrutine;
		private int times;

		private void OnEnable()
		{
			difficult.OnValueChange += (_) => OnDifficultChange();
		}

		private void OnDisable()
		{
			difficult.OnValueChange -= (_) => OnDifficultChange();
		}

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

				yield return new WaitForSeconds(SpawnSpeed.CurrentValue);
			}
		}

		private void OnDifficultChange()
		{
			times += 1;
			SpawnSpeed.CurrentValue -= Mathf.Pow(0.3f, times);
			SpawnSpeed.CurrentValue = Mathf.Clamp(SpawnSpeed.CurrentValue, 0.4f, 1.5f);
		}
	}
}
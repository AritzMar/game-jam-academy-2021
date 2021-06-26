using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
	[SerializeField] private GameObject objectToInstantiate;
	[SerializeField] private int numberOfObjects;
	
	private List<GameObject> instantiatedObjects;

	private void Awake()
	{
		instantiatedObjects = new List<GameObject>();

		for (int i = 0; i < numberOfObjects; i++)
		{
			GameObject newGO = Instantiate(objectToInstantiate);
			newGO.SetActive(false);
			instantiatedObjects.Add(newGO);
		}
	}

	public GameObject GetObject()
	{
		foreach (GameObject gameObject in instantiatedObjects)
		{
			if (!gameObject.activeInHierarchy)
				return gameObject;
		}

		GameObject newGO = Instantiate(objectToInstantiate);
		instantiatedObjects.Add(newGO);

		return newGO;
	}
}

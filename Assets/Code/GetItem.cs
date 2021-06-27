using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GetItem : MonoBehaviour
{
	public Vector3 offset;
	private bool itemSelected;

	public float xFinishCoordinate = -19;
	private void Update()
	{
		if (!itemSelected)
			return;

		if(transform.position.x <= xFinishCoordinate)	//LLEGA AL FINAL AQUÍ HAY QUE PONER EL MÉTODO PARA QUE CUENTE
		{
			ItsFinished();
		}
	}
	private void ItsFinished()
	{
		Destroy(this.gameObject);
		PlaySoundResources.PlaySound_String("GJA_Drop_Card_1");

	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			GetPrefab(other);
		}
	}

	private void GetPrefab(Collider collider)
	{
		if (!CheckIfAvailableSlot(collider.gameObject))
			return;
		PlaySoundResources.PlaySound_String("GJA_Pick_Card_01");
		this.transform.position = collider.transform.position;
		this.transform.parent = collider.transform;
		transform.position += offset ;
		itemSelected = true;
	}

	private bool CheckIfAvailableSlot(GameObject player)
	{
		if (player.GetComponentInChildren<GetItem>())
			return false;
		else
			return true;
	}
}

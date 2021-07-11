using UnityEngine;
using System.Collections;

namespace Chtulhitos.Mechanics
{
	public class Ball : MonoBehaviour, ISpawnable
	{
		private Vector3 positionToGo;
		[SerializeField] private IntVariable ballDamage;

		public Vector3 PositionToGo
		{
			get => new Vector3(transform.position.x, transform.position.y, positionToGo.z);
			set => positionToGo = value;
		}

		void Update()
		{
			transform.position = Vector3.MoveTowards(transform.position, PositionToGo, 5f * Time.deltaTime);
		}

		private void OnTriggerEnter(Collider other)
		{
			IHiteable hitTarget = other.GetComponent<IHiteable>();
			hitTarget?.Hit(ballDamage.CurrentValue, other.transform.position);
			
			if (other.tag == "Player")
			{
				PlaySoundResources.ChangePitch(1.3f);
				PlaySoundResources.PlaySound_String("GJA_UI_Pass_Over");
			}
		}
	}
}
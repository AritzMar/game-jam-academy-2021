using UnityEngine;
using System.Collections;

namespace Chtulhitos.Mechanics
{
	public class Ball : MonoBehaviour, ISpawnable
	{
		private Vector3 positionToGo;
		private int direction;
		[SerializeField] private IntVariable ballDamage;

		public Vector3 PositionToGo
		{
			get => new Vector3(transform.position.x, transform.position.y, positionToGo.z);
			set => positionToGo = value;
		}

		private void Start()
		{
			direction = transform.position.z - PositionToGo.x < 0 ? 1 : -1;
		}

		void Update()
		{
			transform.position = Vector3.MoveTowards(transform.position, PositionToGo, 5f * Time.deltaTime);
			transform.Rotate(Vector3.right * 350 * Time.deltaTime * direction);
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
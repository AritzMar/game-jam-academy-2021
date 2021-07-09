using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

namespace Chtulhitos.Mechanics
{
	public class Torret : MonoBehaviour
	{
		public Transform TorretHead;
		public Transform TorretScope;
		public Material LaserMaterial;
		public float RechargingDuration;
		public Color laserRedColor;
		public Color laserGreenColor;
		public IntVariable turretDamage;
		
		private LineRenderer laserLine;
		private Transform targetToFollow;
		private NavMeshAgent agent = null;
		private Tween colorChangeTween = null;

		private bool recharging = true;
		private bool followTarget = false;
		public void SetFollowCondition(bool condition) => followTarget = condition;

		private void OnEnable() 
		{
			MinigameFloor.OnPinPositionIsPlaying += SetTargetToFollow;
			MinigameFloor.OnPinPositionIdle += Shoot;
		}

		public void StartFollowPlayer() 
		{
			StartCoroutine(PerformSeekAndDestroy());
			recharging = false;
		}

		public void StopFollowPlayer()
		{
			StopCoroutine(PerformSeekAndDestroy());
			laserLine?.SetPosition(1, TorretScope.position);
		}

		private void OnDisable() 
		{
			MinigameFloor.OnPinPositionIsPlaying -= SetTargetToFollow;
			MinigameFloor.OnPinPositionIdle -= Shoot;
		}

		private void SetTargetToFollow(Transform position)
		{
			targetToFollow = position;

			if (agent == null)
				agent = position.GetComponent<NavMeshAgent>();
			
			if(laserLine == null)
				laserLine = gameObject.AddComponent<LineRenderer>();
			//laserLine.widthCurve = widthCurve;
			laserLine.startWidth = 0.2f;
			laserLine.endWidth = 0.2f;
			laserLine.material = LaserMaterial;

			Vector3[] laserDirection = new Vector3[]{TorretScope.position, TorretScope.position};
			laserLine.SetPositions(laserDirection);
			laserLine.useWorldSpace = true;
		}

		private void Shoot()
		{
			if(recharging || !followTarget)
				return;

			recharging = true;

			IHiteable hitTarget = targetToFollow.GetComponent<IHiteable>();
			hitTarget?.Hit(turretDamage.CurrentValue, laserLine.GetPosition(1));

			StartCoroutine(PerformShoot());
		}

		private IEnumerator PerformSeekAndDestroy()
		{
			yield return new WaitUntil(() => targetToFollow != null);

			while(followTarget)
			{
				TorretHead.LookAt(targetToFollow);
				
				if(agent.velocity.sqrMagnitude < 0.1f && colorChangeTween == null)
				{
					laserLine.enabled = true;
					LaserMaterial.color = laserGreenColor;
					laserLine.SetPosition(0, TorretScope.position);
					laserLine.SetPosition(1, targetToFollow.position);
					colorChangeTween = LaserMaterial.DOColor(laserRedColor, 1f).SetEase(Ease.InQuart);
				}
				else if(agent.velocity.sqrMagnitude > 0.1f)
				{
					laserLine.enabled = false;
					colorChangeTween.Kill();
					colorChangeTween = null;
					LaserMaterial.color = laserGreenColor;
				}

				yield return null;
			}
		}

		private IEnumerator PerformShoot()
		{
			PlaySoundResources.PlaySound_String("GJA_Laser_Shot");

			yield return new WaitForSeconds(RechargingDuration);

			recharging = false;
		}
	}
}
using System.Collections;
using UnityEngine;
using DG.Tweening;

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
        //public AnimationCurve widthCurve;
        public IntVariable turretDamage;

        private LineRenderer laserLine;
        private Transform targetToFollow;
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
            laserLine.SetPosition(1, TorretScope.position);
        }

        private void OnDisable() 
        {
            MinigameFloor.OnPinPositionIsPlaying -= SetTargetToFollow;
            MinigameFloor.OnPinPositionIdle -= Shoot;
        }

        private void SetTargetToFollow(Transform position)
        {
            targetToFollow = position;

            if(laserLine == null)
                laserLine = gameObject.AddComponent<LineRenderer>();
            //laserLine.widthCurve = widthCurve;
            laserLine.startWidth = 0.1f;
            laserLine.endWidth = 0.1f;
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

            StartCoroutine(PerformShoot());
            PlaySoundResources.PlaySound_String("GJA_Laser_Shot");
        }

        private IEnumerator PerformSeekAndDestroy()
        {
            yield return new WaitUntil(() => targetToFollow != null);

            while(followTarget)
            {
                TorretHead.LookAt(targetToFollow);
                laserLine.SetPosition(0, TorretScope.position);
                laserLine.SetPosition(1, targetToFollow.position);
                yield return null;
            }
        }

        private IEnumerator PerformShoot()
        {
            float halfRechargingDuration = RechargingDuration / 2;

            LaserMaterial.DOColor(laserRedColor, halfRechargingDuration);

            var mov = targetToFollow.GetComponent<Movement>();
            mov.Hit(turretDamage.CurrentValue);
            
            yield return new WaitForSeconds(halfRechargingDuration);

            LaserMaterial.DOColor(laserGreenColor, halfRechargingDuration);

            yield return new WaitForSeconds(halfRechargingDuration);

            recharging = false;
        }
    }
}
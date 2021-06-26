using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Chtulhitos.Mechanics
{
    public class Torret : MonoBehaviour
    {
        public Transform TorretHead;
        public Transform TorretScope;
        public GameObject BulletPrefab;

        public Material LaserMaterial;
        public float RechargingDuration;

        private LineRenderer laserLine;
        private Transform targetToFollow;
        private bool recharging = false;

        private void OnEnable() 
        {
            MinigameFloor.OnPinPositionIsPlaying += SetTargetToFollow;
            MinigameFloor.OnPinPositionIdle += Shoot;
        }

        private void Start() 
        {
            StartCoroutine(PerformSeekAndDestroy());
                                
            laserLine = gameObject.AddComponent<LineRenderer>();
            laserLine.startWidth = 0.1f;
            laserLine.endWidth = 0.1f;
            laserLine.material = LaserMaterial;
        }

        private void OnDisable() 
        {
            MinigameFloor.OnPinPositionIsPlaying -= SetTargetToFollow;
            MinigameFloor.OnPinPositionIdle -= Shoot;
        }

        private void SetTargetToFollow(Transform position)
        {
            targetToFollow = position;
            Vector3[] laserDirection = new Vector3[]{TorretScope.position, targetToFollow.position};
            laserLine.SetPositions(laserDirection);
            laserLine.useWorldSpace = true;
        }

        private void Shoot()
        {
            if(recharging)
                return;

            recharging = true;

            StartCoroutine(PerformShoot());
        }

        private IEnumerator PerformSeekAndDestroy()
        {
            yield return new WaitUntil(() => targetToFollow != null);

            while(true)
            {
                TorretHead.LookAt(targetToFollow);
                laserLine.SetPosition(1, targetToFollow.position);
                yield return null;
            }
        }

        private IEnumerator PerformShoot()
        {
            float halfRechargingDuration = RechargingDuration / 2;

            var sequence = DOTween.Sequence();

            LaserMaterial.DOColor(Color.red, halfRechargingDuration);

            yield return new WaitForSeconds(halfRechargingDuration);

            LaserMaterial.DOColor(Color.blue, halfRechargingDuration);

            yield return new WaitForSeconds(halfRechargingDuration);

            recharging = false;
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Chtulhitos.Mechanics
{
    public class Torret : MonoBehaviour
    {
        public Transform TorretHead;
        public Transform TorretScope;
        public Transform TargetToFollow;

        public GameObject BulletPrefab;

        private void OnEnable() 
        {
            MinigameFloor.OnPinPositionIsPlaying += SetTargetToFollow;
            MinigameFloor.OnPinPositionIdle += Shoot;
        }

        private void Start() 
        {
            StartCoroutine(PerformSeekAndDestroy());
        }

        private void OnDisable() 
        {
            MinigameFloor.OnPinPositionIsPlaying -= SetTargetToFollow;
            MinigameFloor.OnPinPositionIdle -= Shoot;
        }

        private Transform SetTargetToFollow(Transform position) => TargetToFollow = position;
        private void Shoot()
        {
            Debug.Log("PAWN!");
            Bullet tempBullet = Instantiate(BulletPrefab, TorretScope.position, Quaternion.identity).GetComponent<Bullet>();
            Vector3 signalPosition = TargetToFollow.position;
            tempBullet.SetPositionToGo(signalPosition);
        }

        private IEnumerator PerformSeekAndDestroy()
        {
            yield return new WaitUntil(() => TargetToFollow != null);

            while(true)
            {
                TorretHead.LookAt(TargetToFollow);
                yield return null;
            }
        }
    }
}
using System.Collections;
using UnityEngine;
using System;

public class MinigameFloor : MonoBehaviour
{
    public static Func<Transform, Transform> OnPinPositionIsPlaying;
    public static Action OnPinPositionIdle;

    [SerializeField] private Pin pinTarget;

    [SerializeField] private float checkingSpeed;
    [SerializeField] private float checkingDistance;
    private IEnumerator checkingCorroutine;

    private void Start() 
    {
        checkingCorroutine = CheckLastPosition();
        StartCoroutine(checkingCorroutine);

        if(OnPinPositionIsPlaying != null)
            OnPinPositionIsPlaying(pinTarget.transform);
    }

    public IEnumerator CheckLastPosition()
    {
        while(true)
        {
            Transform lastLocation = pinTarget.CloneLocation();

            yield return new WaitForSeconds(checkingSpeed);

            if(Vector3.Distance(lastLocation.position, pinTarget.CloneLocation().position) <= checkingDistance)
            {

                if(OnPinPositionIdle != null)
                    OnPinPositionIdle();
            }
        }
    }
}

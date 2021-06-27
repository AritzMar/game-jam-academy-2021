using System.Collections;
using UnityEngine;
using System;

public class MinigameFloor : MonoBehaviour
{
    public static Action<Transform> OnPinPositionIsPlaying;
    public static Action OnPinPositionIdle;

    [SerializeField] private Pin pinTarget;
    [SerializeField] private float checkingSpeed;
    [SerializeField] private float checkingDistance;
    private IEnumerator checkingCorroutine;

    public void DoChecking() 
    {
        checkingCorroutine = CheckLastPosition();
        StartCoroutine(checkingCorroutine);
    }

    public IEnumerator CheckLastPosition()
    {
        if(OnPinPositionIsPlaying != null)
            OnPinPositionIsPlaying(pinTarget.transform);

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

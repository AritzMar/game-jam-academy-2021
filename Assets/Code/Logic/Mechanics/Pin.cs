using UnityEngine;

public class Pin : MonoBehaviour
{
    private GameObject shadowPin;

    private void Awake() 
    {
        shadowPin = new GameObject();
        shadowPin.name = "LastPointPlayer";
    }

    public Transform CloneLocation()
    {
        shadowPin.transform.position = transform.position;
        return shadowPin.transform;
    }
}

using UnityEngine;

public class Pin : MonoBehaviour
{
    private GameObject shadowPin;

    private void Start() 
    {
        shadowPin = new GameObject();
    }

    public Transform CloneLocation()
    {
        shadowPin.transform.position = transform.position;
        return shadowPin.transform;
    }
}

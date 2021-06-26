using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Vector3 positionToGo;

    public void SetPositionToGo(Vector3 position) => positionToGo = position;

    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToGo, 3f * Time.deltaTime);
    }    
}
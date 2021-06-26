using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta_bullet : MonoBehaviour
{

   public  float speed;
    public float ttl;
    public Transform posicion;
    
    void start()
    {
        shoot();
        Destroy(gameObject, ttl);

    }
    void shoot()
    {
        transform.Translate(posicion.position * speed * Time.deltaTime, Space.World);
    }
}

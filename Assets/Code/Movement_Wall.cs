using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Wall : MonoBehaviour
{
    public float speed;
    public float distancia;
    public float distanciamaxima;

    public Transform position;
    // Update is called once per frame
    void Update()
    {
        float distanciaclaculo = Vector3.Distance(transform.position, position.position);
        
        if (distanciaclaculo <= distancia)
            speed = -speed;


        if (distanciaclaculo >= distanciamaxima)
            speed = -speed;

        Debug.Log(distanciaclaculo);

        transform.Translate(speed * Time.deltaTime, 0, 0);


        /*
         *  
         *  IEnumerator move1()
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.2f);
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            yield return new WaitForSeconds(0.2f);

        }
        StartCoroutine(move1());
        ///movimiento izquierda
        if (transform.position.x <= 5)
        {
            speed = -speed;
        }
        //movimiento derecha
        if (transform.position.x >= 15)
            speed = -speed;

        Debug.Log(transform.position.x);
        Debug.Log(speed);
        */
    }
}

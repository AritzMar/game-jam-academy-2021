using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_shoot : MonoBehaviour
{
    public GameObject bulletperfab;
    public Transform shotpoint;
    public Transform player;
    bool figth = true;

    void Update()
    {
        StartCoroutine(esperar());
    }

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(3);
        Instantiate(bulletperfab, shotpoint.position, Quaternion.identity);
        figth= false;

    }
}

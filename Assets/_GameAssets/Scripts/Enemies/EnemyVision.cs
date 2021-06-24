using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float visionDistance = 3f;  

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); 
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.layer == 10)
            {
                hit.collider.gameObject.GetComponent<PlayerHealth>().RemoveLife(50);
                //Llamada a método inmolación de clase EnemyAnimation
                Destroy(gameObject);
            }
        }       
        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);
    }   
}
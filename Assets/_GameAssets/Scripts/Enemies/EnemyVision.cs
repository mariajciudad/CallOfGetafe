using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detecta al player a través de un raycast y explota para herirlo
public class EnemyVision : MonoBehaviour
{
    public float visionDistance;
    Transform visionPoint;
    public int damage;    

    private void Awake()
    {
        //Como mis enemigos tienen el pivote en los pies, un gameobject vacío en el centro será el punto donde surja el raycast
        visionPoint = transform.Find("VisionPoint");
    }

    void Update()
    {
        Ray ray = new Ray(visionPoint.transform.position, visionPoint.transform.forward); 
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.layer == 10)
            {               
                hit.collider.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);                
                Destroy(gameObject);
            }
        }       
        
        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);
    }   
}
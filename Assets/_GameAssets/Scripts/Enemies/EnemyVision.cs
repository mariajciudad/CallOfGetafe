using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detecta al player a través de un raycast y explota para herirlo
public class EnemyVision : MonoBehaviour
{
    public float visionDistance;
    Transform visionPoint;
    public int damage;
    public ActivateBoss activateboss;

    public SoundManager soundManager;

    private void Awake()
    {
        //Como mis enemigos tienen el pivote en los pies, un gameobject vacío en el centro será el punto donde surja el raycast
        visionPoint = transform.Find("VisionPoint");

        activateboss = GameObject.Find("ActivateBoss").GetComponent<ActivateBoss>();
    }

    void Update()
    {   //Creación del raycast 
        Ray ray = new Ray(visionPoint.transform.position, visionPoint.transform.forward); 
        RaycastHit hit;
        //Al detectar el collider del player, accede a su vida y le hiere, además de destruirse
        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.layer == 10)
            {                                  
                hit.collider.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);
                activateboss.addKilledEnemies();
                Destroy(gameObject);                
            }
        }       
        
        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);       
    }   
}
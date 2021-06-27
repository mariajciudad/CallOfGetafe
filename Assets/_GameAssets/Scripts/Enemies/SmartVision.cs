using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detecta al player a través de un raycast y lo persigue, hiriéndolo al tocarlo pero sin explotar
public class SmartVision : EnemyVision
{    
    [SerializeField] SmartAgent smartAgent;
    Transform visionPointSmart;
    public bool isEnter = true;  //Variable para que los enemigos golpeen una sola vez al FPSController del player estando en su trigger
    private bool isLooking; //Variable para que no se reproduzca un sonido indefinidamente mientras está en un trigger

    private void Awake()
    {
        //Como mis enemigos tienen el pivote en los pies, un gameobject vacío en el centro será el punto donde surja el raycast
        visionPointSmart = transform.Find("VisionPoint");

        isLooking = true;
    }

    void Update()
    {
        //Persigue al player si colisiona con su collider y reproduce una vez un audio
        Ray ray = new Ray(visionPointSmart.transform.position, visionPointSmart.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.layer == 10)
            {
                if (isLooking)
                {
                    isLooking = false;
                    smartAgent.ChasePlayer(hit.collider.transform);                   
                    soundManager.EnemySoundSeePlayer();
                }                      
            } 
            else
            {
                isLooking = true;
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);

    }

    //Al entrar el player en el collider triggeado, accede a su vida para herirlo una sola vez
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if(isEnter)
            {
                isEnter = false;
                other.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);
                soundManager.EnemySoundAttack();
            }                                      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            isEnter = true;
        }
    }
}

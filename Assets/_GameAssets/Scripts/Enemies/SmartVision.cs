using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detecta al player a través de un raycast y lo persigue, hiriéndolo al tocarlo pero sin explotar
public class SmartVision : EnemyVision
{    
    [SerializeField] SmartAgent smartAgent;
    Transform visionPointSmart;
    public bool isEnter = true;  //Variable para que los enemigos golpeen una sola vez al FPSController del player  


    private bool isLooking;

    private void Awake()
    {
        //Como mis enemigos tienen el pivote en los pies, un gameobject vacío en el centro será el punto donde surja el raycast
        visionPointSmart = transform.Find("VisionPoint");

        isLooking = true;
    }

    void Update()
    {
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
                    //Llamada a método inmolación de clase EnemyAnimation
                    soundManager.EnemySoundRandom();
                }                    
               
            } 
            else
            {
                isLooking = true;
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);

    }

    //Al entrar el player en el collider triggeado, accede a su vida para herirlo una vez
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if(isEnter)
            {
                isEnter = false;
                other.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);   
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


    /* //SOLO LE DA UN GOLPE Y YA ESTA, HASTA QUE VUELVA A CHOCAR, FUNCIONA CON EL OTRO PLAYER EL DEL RIGIDBODY
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (isEnter)
            {
                collision.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);
                isEnter = false;
                Debug.Log("Enemigo ha chocado con player");
                Debug.Log("El enemigo le ha quitado al player de vida: " + damage);
            }
        }
    }    

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            isEnter = true;
        }
    }
    */

}

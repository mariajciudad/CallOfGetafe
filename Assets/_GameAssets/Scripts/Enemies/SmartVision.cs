using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Detecta al player a través de un raycast y lo persigue, hiriéndolo al tocarlo pero sin explotar
public class SmartVision : EnemyVision
{    
    [SerializeField] SmartAgent smartAgent;
    Transform visionPointSmart;

    private void Awake()
    {
        //Como mis enemigos tienen el pivote en los pies, un gameobject vacío en el centro será el punto donde surja el raycast
        visionPointSmart = transform.Find("VisionPoint");
    }

    void Update()
    {
        Ray ray = new Ray(visionPointSmart.transform.position, visionPointSmart.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, visionDistance))
        {
            if (hit.collider.gameObject.layer == 10)
            {
                smartAgent.ChasePlayer(hit.collider.transform);
                //Llamada a método inmolación de clase EnemyAnimation
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * visionDistance, Color.red);
    }

    //SOLO LE DA UN GOLPE Y YA ESTA, HASTA QUE VUELVA A CHOCAR, FUNCIONA CON EL OTRO PLAYER EL DEL RIGIDBODY
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            other.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);
            Debug.Log("Enemigo ha chocado con player");
            Debug.Log("El enemigo le ha quitado al player de vida: " + damage);
        }
    }

    /*  FUNCIONA PERO LE QUITA MUCHA VIDA AL PLAYER HASTA MATARLO, EN PLAN METRALLETA
     * private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);
            Debug.Log("Enemigo ha chocado con player");
            Debug.Log("El enemigo le ha quitado al player de vida: " + damage);
        }
    }
    */
}
   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] int shootDistance;

    void Start()
    {
        
    }
     
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Se crea el raycast desde el shoot point y se obtiene información del objeto con el que colisiona
            Ray ray = new Ray(shootPoint.transform.position, shootPoint.transform.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * shootDistance, Color.red);

            //Comprueba si el rayo choca con un enemigo
            if (Physics.Raycast(ray.origin, ray.direction, out hit, shootDistance))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Destroy(hit.collider.gameObject);                 
                }
            }
        }
    }
}

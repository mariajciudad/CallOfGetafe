using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycastAll : MonoBehaviour
{
    public Camera cam; //Se declara la camara

    void Start()
    {
        cam = Camera.main; //Se referencia la camara
        //Tambien se pueden referenciar asi: cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Cuando se pulsa el boton izquierdo del raton se ejecuta el if
        {
            //Se crea el raycast para un juego shooter. El rayo tiene que tener un punto de origen y una direccion
            //Hay varias maneras de crear un raycast:

            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //El rayo va a ir desde un punto de la pantalla (la camara) hacia adelante apuntando a donde este el raton. Es un rayo cada frame

            Ray ray2 = new Ray(transform.position, transform.right); //El rayo sale desde el punto de origen (el pivote, normalmente el centro) en direccion a la derecha

            Ray ray3 = new Ray(transform.position + transform.right * 0.5f, transform.right); //El rayo sale desde el punto de origen mas 0.5 a la derecha, en direccion a la derecha...........

            Ray ray4 = new Ray(new Vector3(3, 3, 3), new Vector3(0, 1, 0)); //El rayo sale desde el punto de origen.............................


            RaycastHit hit; //Es informacion del supuesto choque del rayo con algo. Es como hacer un OnTriggerEnter (Collider other), hit seria el other (el objeto con el que ha chocado?)

            //Comprueba si el rayo choca con algo
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 50)) //Raycast es una funcion que va a tratar el ray y el hit. Procede de la clase Physics. Obtiene el origen y direccion del rayo, 50 es la distancia de comprobacion (el rayo solo llega hasta los 50 metros)
            {
                if (hit.collider.gameObject.layer == 16) //Accede al collider del objeto con el que choca el rayo solo si el objeto tiene asignado el Layer nº16 
                {
                    Destroy(hit.collider.gameObject); //Se destruye el collider del objeto 
                }
            }
         
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.red); //Se dibuja el rayo para que se vea, es una simulacion
        }
    }
}




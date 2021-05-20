using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioClip;

    private GameObject player; //Se crea una variable de tipo Gameobject para el player

    private float distance;
    private bool contactFar = true;
    private bool contactNear = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  //Se accede a la posici�n y a la rotaci�n del tag Player   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)  //El collider trigger se ejecuta indefinidamente
    {
        distance = Vector3.Distance(player.transform.position, transform.position);  //Calcula la distancia entre la posicion del player y la del objeto que tiene el script

        print("La distancia del player hasta el perro es: " + distance);

        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(player.transform.position);

            if (distance > 5)
            {
                if (contactFar)
                {                    
                    audioSource.PlayOneShot(audioClip[0]);                    
                    contactFar = false;
                }
            }
            else if (distance < 2) {
                if (contactNear)
                {                    
                    audioSource.PlayOneShot(audioClip[1]);
                    contactNear = false;
                }
            }            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            contactFar = true;
            contactNear = true;
        }
    }
}

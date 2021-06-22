using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioClip;

    private GameObject player; 

    private float distance;
    private bool contactFar = true;
    private bool contactNear = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  //Se accede a la posición y a la rotación del tag Player   
    }


    private void OnTriggerStay(Collider other)  //El collider trigger se ejecuta indefinidamente
    {
        distance = Vector3.Distance(player.transform.position, transform.position);  //Calcula la distancia entre la posicion del player y la del objeto que tiene el script
               
        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(player.transform.position);

            if (distance >= 3.5f && distance <= 4.5f)
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

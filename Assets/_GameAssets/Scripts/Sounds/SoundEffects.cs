using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] audioClip;

    Transform player;  //Se crea una variable de tipo Transform
    Transform dog;

    private float distance;
    private bool contactFar = true;
    private bool contactNear = true;


    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Dog").transform;  //Se accede a la posición y a la rotación del gameobject Dog   
        player = GameObject.FindGameObjectWithTag("Player").transform;  //Se accede a la posición y a la rotación del tag Player   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)  //El collider trigger se ejecuta indefinidamente
    {
        distance = Vector3.Distance(player.position, dog.position);  //Calcula la distancia entre la posicion del player y la del dog

        print("La distancia del player hasta el perro es: " + distance);

        if (other.gameObject.CompareTag("Player"))
        {
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

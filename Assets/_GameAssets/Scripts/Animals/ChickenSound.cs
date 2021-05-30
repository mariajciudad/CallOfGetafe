using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip audioClip;

    private GameObject player; //Se crea una variable de tipo Gameobject para el player


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  //Se accede a la posición y a la rotación del tag Player   
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)  //El collider trigger se ejecuta indefinidamente
    {
        audioSource.PlayOneShot(audioClip);
    }
}
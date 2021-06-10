using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip audioClip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
        }
        
    }
}

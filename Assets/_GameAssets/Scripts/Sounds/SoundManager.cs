using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip audioClip;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            audioSource.PlayOneShot(audioClip);
        }        
    }

    public void EnemySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    public void EnemySound()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    public void EnemySoundRandom()
    {
        audioSource.PlayOneShot(audioClip[Random.Range(0, audioClip.Length)]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona los audios de los enemigos
public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipAttack;
    public AudioClip[] audioClipHurt;
    public AudioClip[] audioClipSeePlayer;

    public void EnemySoundSeePlayer()
    {
        audioSource.PlayOneShot(audioClipSeePlayer[Random.Range(0, audioClipSeePlayer.Length)]);
    }

    public void EnemySoundAttack()
    {
        audioSource.PlayOneShot(audioClipAttack);
    }

    public void EnemySoundHurt()
    {
        audioSource.PlayOneShot(audioClipHurt[Random.Range(0, audioClipHurt.Length)]);
    }
     
}

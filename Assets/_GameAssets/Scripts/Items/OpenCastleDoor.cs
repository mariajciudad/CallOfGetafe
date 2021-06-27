using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Al coger la llave, se abre la puerta del castillo
public class OpenCastleDoor : MonoBehaviour
{
    [SerializeField] Animator animator; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            animator.SetBool("Open", true);
            Destroy(gameObject);
        }
    }
}

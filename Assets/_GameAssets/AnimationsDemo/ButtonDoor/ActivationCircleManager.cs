using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationCircleManager : MonoBehaviour
{
    /* Opcion 1, es mas generica que la opcion 2
     * public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.enabled = true; //Se activa el Animator Controller
        }
    }
    */


    /* Opcion 2, es mas especifica
    private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator = GameObject.Find("Door").GetComponent<Animator>();
            animator.enabled = true;            
        }
    }
    */

    // Opcion 3, menos sencilla pero mejor hecha
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", true); //Se pone a true el parametro Open del Animator (se activa la transicion Open)
        }
    }
}

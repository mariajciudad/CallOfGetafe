using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoorAnimation : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            animator.SetBool("Open", true);
            //animator.enabled = true; 
        }
    }

}

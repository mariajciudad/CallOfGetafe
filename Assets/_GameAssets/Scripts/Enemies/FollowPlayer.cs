using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    public float speed;

    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)  //El collider trigger se ejecuta indefinidamente
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Walk", true);
            transform.position = Vector3.MoveTowards(transform.position, targetToFollow.transform.position, speed);
            transform.LookAt(targetToFollow.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Walk", false);
    }

}

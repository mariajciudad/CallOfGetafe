using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    public float movementSpeed;
    public float distanceToFollow;
    private float distanceToPlayer;
    [SerializeField] Animator animator;
    public bool isFirstMeeting;

    [SerializeField] SoundManager soundManager;

    private void Start()
    {
        isFirstMeeting = true;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, targetToFollow.transform.position);

        if (distanceToPlayer <= distanceToFollow)
        {            
            transform.LookAt(targetToFollow.transform.position);            
            transform.position = Vector3.MoveTowards(transform.position, targetToFollow.transform.position, movementSpeed);
            animator.SetBool("Walk", true);

           if (isFirstMeeting)
           {
                isFirstMeeting = false;         
                soundManager.EnemySound();
           }            
        }
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Walk", false);
    }
    */


}

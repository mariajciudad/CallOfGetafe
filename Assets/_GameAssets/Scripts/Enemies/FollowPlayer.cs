using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;    
    private float distanceToPlayer;
    public float distanceToFollow;
    public float movementSpeed;

    [SerializeField] Animator animator;
   
    public bool isFirstMeeting;
    [SerializeField] SoundManager soundManager;

    private void Start()
    {
        isFirstMeeting = true;
    }

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
        else
        {
            animator.SetBool("Walk", false);
        }

    }
}

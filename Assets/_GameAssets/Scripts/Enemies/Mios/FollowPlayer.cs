using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;    
    private float distanceToPlayer;
    public float distanceToFollow;
    public float movementSpeed; 
    public bool isFirstMeeting;
    [SerializeField] EnemyAnimations enemyAnimations;
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

            enemyAnimations.ChangeStateToWalk();

           if (isFirstMeeting)
           {
                isFirstMeeting = false;         
                soundManager.EnemySoundAttack();
           }            
        } 
        else
        {
            enemyAnimations.ChangeStateToIdle();
        }
    }
}

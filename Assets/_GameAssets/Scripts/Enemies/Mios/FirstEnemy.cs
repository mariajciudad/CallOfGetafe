using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Gestiona el movimiento del primer enemigo. Cuando el player esta cerca de él, lo persigue
public class FirstEnemy : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;    
    private float distanceToPlayer;
    public float distanceToFollow;
    public float movementSpeed; 
    public bool isFirstMeeting;
    [SerializeField] EnemyAnimations enemyAnimations;
    [SerializeField] SoundManager soundManager;
    [SerializeField] int firstEnemyLife;
    public bool isEnter = true;
    public int damage;
    [SerializeField] Slider healthBarSlider;
    [SerializeField] Image healthBarColor;


    private void Start()
    {
        isFirstMeeting = true;
        healthBarSlider.value = firstEnemyLife;
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

    //Hiere al player al entrar en su trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            if (isEnter)
            {
                isEnter = false;
                other.gameObject.GetComponent<PlayerHealth>().RemoveLife(damage);          
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            isEnter = true;
        }
    }

    public void RemoveLife(int damage)
    {
        firstEnemyLife -= damage;

        HealthBar(firstEnemyLife);

        soundManager.EnemySoundHurt();

        if (firstEnemyLife <= 0)
        {
             Destroy(gameObject);
        }
    }

    public void HealthBar(int amount)
    {
        healthBarSlider.value = firstEnemyLife;

        if (amount >= 50)
        {
            healthBarColor.color = new Color32(19, 233, 109, 255);
        }

        else if (amount > 25 && amount < 50)
        {
            healthBarColor.color = new Color32(233, 223, 19, 255);
        }
        else
        {
            healthBarColor.color = new Color32(233, 19, 25, 255);
        }
    }
}

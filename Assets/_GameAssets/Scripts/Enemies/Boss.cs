using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Gestiona el comportamiento de los enemigos listos, heredando de CrazyAgent
//Los enemigos listos se dirigen a los puntos de destino en orden y al ver al player, lo persiguen

public class Boss : CrazyAgent
{
    [SerializeField] int nextPosition;
    [SerializeField] string destinyPointsNameTag;
    [SerializeField] public float runSpeed;
    public EnemyLife enemyLife;
    
    void Awake()
    {   //Rellena el array con los puntos de destino ddel boss    
        targets = GameObject.FindGameObjectsWithTag(destinyPointsNameTag);
        actualTarget = targets[0].transform;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    //Se sobreescribe el método ChangeDestination() heredado
    public override void ChangeDestination()
    {
        nextPosition++;

        //Evita que la siguiente posición sea superior al tamaño del array de destinos
        if (nextPosition == targets.Length)
        {
            nextPosition = 0;
        }

        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        StartCoroutine(CoroutineStopSliding(nextPosition));
    }

    //Cuando ve al player, su target deja de ser los puntos de destino y lo persigue corriendo
    public void ChasePlayer(Transform t)
    {
        actualTarget = t;
        enemyAnimations.ChangeStateToRun();
        agent.speed = runSpeed;  
    }

}

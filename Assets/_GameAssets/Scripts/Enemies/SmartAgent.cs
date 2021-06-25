using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Gestiona el comportamiento de los enemigos listos, heredando de CrazyAgent
//Los enemigos listos se dirigen a los puntos de destino en orden y al ver al player, lo persigue

public class SmartAgent : CrazyAgent
{
    [SerializeField] int nextPosition;

    //Se sobreescribe el método ChangeDestination() heredado
    public override void ChangeDestination()
    {
        nextPosition++;
                
        if (nextPosition == targets.Length)
        {
            nextPosition = 0;
        }

        agent.velocity = Vector3.zero;
        agent.isStopped = true;
        StartCoroutine(CoroutineStopSliding(nextPosition));        
    }

    //Cuando ve al player, su target deja de ser los puntos de destino y lo persigue
    public void ChasePlayer(Transform t)
    {
        actualTarget = t;
    }
}
